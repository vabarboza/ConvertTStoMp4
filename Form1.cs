using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Xabe.FFmpeg;

namespace ConvertTStoMp4
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void btnFiles_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    tbFiles.Text = dialog.SelectedPath;
                    lbFiles.Items.Clear();

                    string[] inputFiles = Directory.GetFiles(dialog.SelectedPath, "*.*")
                                                   .OrderBy(f => Path.GetFileName(f))
                                                   .ToArray();

                    foreach (string file in inputFiles)
                    {
                        lbFiles.Items.Add(file);
                    }

                    cbSpeed.Items.Clear();
                    cbSpeed.Items.Add("Intel");
                    cbSpeed.Items.Add("Nvidia");
                    cbSpeed.Items.Add("AMD");
                }
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = folderDialog.SelectedPath;
                    tbOutput.Text = selectedFolder; // Atualiza o texto na caixa de texto
                }
            }
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            string outputFolder = tbOutput.Text;
            cbSpeed.Enabled = false;

            if (lbFiles.Items.Count == 0)
            {
                MessageBox.Show("Nenhum arquivo selecionado.");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                MessageBox.Show("Pasta de saída não encontrada. Criando pasta...");
                Directory.CreateDirectory(outputFolder);
            }

            List<string> filesToConvert = lbFiles.Items.Cast<string>().ToList();

            foreach (string inputFile in filesToConvert)
            {
                string outputFile = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputFile) + ".mp4");
                await ConvertToMKV(inputFile, outputFile);

                // Remove the item from the list after conversion
                lbFiles.Items.Remove(inputFile);
            }

            if (cbShutdown.Checked)
            {
                Process.Start("shutdown", "/s /t 0");
            } else
            {
                MessageBox.Show("Conversão concluída.");
            }

            cbSpeed.Enabled = true;
        }

        private async Task ConvertToMKV(string inputPath, string outputPath)
        {
            try
            {
                // Defina o caminho para os executáveis do FFmpeg
                string ffmpegPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg");
                FFmpeg.SetExecutablesPath(ffmpegPath);

                var mediaInfo = await FFmpeg.GetMediaInfo(inputPath);
                var videoStream = mediaInfo.VideoStreams.FirstOrDefault();
                var audioStream = mediaInfo.AudioStreams.FirstOrDefault();
                var legend = mediaInfo.SubtitleStreams.FirstOrDefault();

                if (videoStream == null || audioStream == null)
                {
                    MessageBox.Show($"Arquivo de entrada {inputPath} não possui streams de vídeo ou áudio válidas.");
                    return;
                }

                string selectedPreset = cbSpeed.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedPreset))
                {
                    MessageBox.Show("Nenhum preset selecionado.");
                    return;
                }

                IConversion conversion = FFmpeg.Conversions.New()
                    .AddStream(videoStream)
                    .AddStream(audioStream);

                if (legend != null)
                {
                    conversion.AddStream(legend);
                }

                switch (selectedPreset)
                {
                    case "Intel":
                        conversion
                            .AddParameter("-c:v libx265")
                            .AddParameter("-preset slow")
                            .AddParameter("-b:v 3200k");
                        break;
                    case "Nvidia":
                        conversion
                            .AddParameter("-c:v hevc_nvenc")
                            .AddParameter("-preset slow")
                            .AddParameter("-b:v 3200k");
                        break;
                    case "AMD":
                        conversion
                            .AddParameter("-c:v hevc_amf")
                            .AddParameter("-preset slow")
                            .AddParameter("-b:v 3200k");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                conversion
                    .SetOutput(outputPath)
                    .SetOverwriteOutput(true)
                    .SetOutputFormat(Format.matroska);

                conversion.OnProgress += (sender, args) =>
                {
                    Invoke(new Action(() =>
                    {
                        pbStatus.Value = (int)args.Percent;
                        labelStatus.Text = $"Convertendo: {Path.GetFileNameWithoutExtension(inputPath).Substring(0, Math.Min(70, Path.GetFileNameWithoutExtension(inputPath).Length))}";
                        labelPercent.Text = $"{args.Percent}%";
                    }));
                };

                await conversion.Start();

                Invoke(new Action(() =>
                {
                    labelStatus.Text = $"Conversão concluída: {Path.GetFileName(inputPath)}";
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao converter o arquivo {inputPath}: {ex.Message}");
                Invoke(new Action(() =>
                {
                    labelStatus.Text = $"Erro: {ex.Message}";
                }));
            }
        }
    }
}
