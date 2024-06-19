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
                    cbSpeed.Items.Add("Medium");
                    cbSpeed.Items.Add("Fast");
                    cbSpeed.Items.Add("Faster");
                    cbSpeed.Items.Add("SuperFast");
                    cbSpeed.Items.Add("UltraFast");
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

            foreach (string inputFile in lbFiles.Items)
            {
                string outputFile = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputFile) + ".mp4");
                await ConvertToMP4(inputFile, outputFile);
            }

            MessageBox.Show("Conversão concluída.");
        }

        private async Task ConvertToMP4(string inputPath, string outputPath)
        {
            try
            {
                var mediaInfo = await FFmpeg.GetMediaInfo(inputPath);
                var videoStream = mediaInfo.VideoStreams.FirstOrDefault();
                var audioStream = mediaInfo.AudioStreams.FirstOrDefault();

                if (videoStream == null || audioStream == null)
                {
                    MessageBox.Show($"Arquivo de entrada {inputPath} não possui streams de vídeo ou áudio válidas.");
                    return;
                }

                var conversion = FFmpeg.Conversions.New()
                    .AddStream(videoStream)
                    .AddStream(audioStream)
                    .AddParameter("-c:v hevc_nvenc")
                    .AddParameter("-preset slow")
                    .AddParameter("-b:v 3000k")
                    .SetOutput(outputPath)
                    .SetOverwriteOutput(true);

                string selectedPreset = cbSpeed.SelectedItem.ToString();

                switch (selectedPreset)
                {
                    case "Medium":
                        conversion.SetPreset(ConversionPreset.Medium);
                        break;
                    case "Fast":
                        conversion.SetPreset(ConversionPreset.Fast);
                        break;
                    case "Faster":
                        conversion.SetPreset(ConversionPreset.Faster);
                        break;
                    case "SuperFast":
                        conversion.SetPreset(ConversionPreset.SuperFast);
                        break;
                    case "UltraFast":
                        conversion.SetPreset(ConversionPreset.UltraFast);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

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
