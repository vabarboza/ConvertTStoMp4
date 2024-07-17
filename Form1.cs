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
                MessageBox.Show("Pasta de sa�da n�o encontrada. Criando pasta...");
                Directory.CreateDirectory(outputFolder);
            }

            List<string> filesToConvert = lbFiles.Items.Cast<string>().ToList();

            foreach (string inputFile in filesToConvert)
            {
                string outputFile = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputFile) + ".mp4");
                await ConvertToMP4(inputFile, outputFile);

                // Remove the item from the list after conversion
                lbFiles.Items.Remove(inputFile);
            }

            MessageBox.Show("Convers�o conclu�da.");
            cbSpeed.Enabled = true;
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
                    MessageBox.Show($"Arquivo de entrada {inputPath} n�o possui streams de v�deo ou �udio v�lidas.");
                    return;
                }

                var conversion = FFmpeg.Conversions.New()
                    .AddStream(videoStream)
                    .AddStream(audioStream)
                    .AddParameter("-preset fast")
                    .AddParameter("-b:v 3500k")
                    .SetOutput(outputPath)
                    .SetOverwriteOutput(true);

                string selectedPreset = cbSpeed.SelectedItem.ToString();

                switch (selectedPreset)
                {
                    case "Intel":
                        conversion.AddParameter("-c:v libx265");
                        break;
                    case "Nvidia":
                        conversion.AddParameter("-c:v hevc_nvenc");
                        break;
                    case "AMD":
                        conversion.AddParameter("-c:v hevc_amf");
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
                    labelStatus.Text = $"Convers�o conclu�da: {Path.GetFileName(inputPath)}";
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
