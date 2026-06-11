using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Platform.Storage;
using Avalonia.Controls.Shapes;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
namespace lab10.Views;

public partial class MainWindow : Window
{
    private List<FastaSequence> sequences = new();
    public MainWindow()
    {
        InitializeComponent();
    }
    private async void LoadFasta_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            var files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Wybierz pliki FASTA",
                AllowMultiple = true,
                FileTypeFilter =
                [
                    new FilePickerFileType("FASTA")
                    {
                        Patterns = ["*.fasta", "*.fa", "*.txt"]
                    }
                ]
            });

            if (files.Count == 0)
                return;

            List<string> paths = new();

            foreach (var file in files)
            {
                if (file.Path.LocalPath != null)
                    paths.Add(file.Path.LocalPath);
            }

            sequences = FastaParser.ReadFastaFiles(paths);

            SequencesList.ItemsSource = sequences;
            DetailsBox.Text = $"Wczytano sekwencji: {sequences.Count}";

            DrawChart();
        }
        catch (Exception ex)
        {
            DetailsBox.Text = "B³¹d: " + ex.Message;
        }
    }

    private void SequencesList_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        int index = SequencesList.SelectedIndex;

        if (index < 0 || index >= sequences.Count)
            return;

        FastaSequence seq = sequences[index];

        DetailsBox.Text =
            $"Nazwa: {seq.Name}\n" +
            $"Nag³ówek: {seq.Header}\n" +
            $"D³ugoœæ: {seq.Length}\n" +
            $"GC: {seq.GCContent}%\n" +
            $"Liczba kodonów: {seq.CodonCount}\n\n" +
            $"A: {seq.CountA}\n" +
            $"T: {seq.CountT}\n" +
            $"G: {seq.CountG}\n" +
            $"C: {seq.CountC}\n\n" +
            $"Sekwencja:\n{seq.Sequence}";
    }

    private async void ExportCsv_Click(object? sender, RoutedEventArgs e)
    {
        if (sequences.Count == 0)
        {
            DetailsBox.Text = "Najpierw wczytaj plik FASTA.";
            return;
        }

        var file = await StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Zapisz CSV",
            SuggestedFileName = "wyniki.csv"
        });

        if (file == null)
            return;

        StringBuilder sb = new();

        sb.AppendLine("Name,Header,Length,GCContent,CodonCount,A,T,G,C");

        foreach (var seq in sequences)
        {
            sb.AppendLine($"{seq.Name},{seq.Header},{seq.Length},{seq.GCContent},{seq.CodonCount},{seq.CountA},{seq.CountT},{seq.CountG},{seq.CountC}");
        }

        await File.WriteAllTextAsync(file.Path.LocalPath, sb.ToString(), Encoding.UTF8);

        DetailsBox.Text = "Zapisano plik CSV.";
    }

    private async void ExportJson_Click(object? sender, RoutedEventArgs e)
    {
        if (sequences.Count == 0)
        {
            DetailsBox.Text = "Najpierw wczytaj plik FASTA.";
            return;
        }

        var file = await StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Zapisz JSON",
            SuggestedFileName = "wyniki.json"
        });

        if (file == null)
            return;

        string json = JsonSerializer.Serialize(sequences, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        await File.WriteAllTextAsync(file.Path.LocalPath, json, Encoding.UTF8);

        DetailsBox.Text = "Zapisano plik JSON.";
    }

    private void DrawChart()
    {
        ChartCanvas.Children.Clear();

        if (sequences.Count == 0)
            return;

        double canvasWidth = 1000;
        double canvasHeight = 220;

        double maxLength = sequences.Max(s => s.Length);
        double barWidth = Math.Max(20, canvasWidth / sequences.Count - 10);

        for (int i = 0; i < sequences.Count; i++)
        {
            var seq = sequences[i];

            double barHeight = seq.Length / maxLength * 170;
            double x = 20 + i * (barWidth + 10);
            double y = canvasHeight - barHeight - 30;

            Rectangle rect = new Rectangle
            {
                Width = barWidth,
                Height = barHeight,
                Fill = Brushes.SteelBlue
            };

            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);
            ChartCanvas.Children.Add(rect);

            TextBlock label = new TextBlock
            {
                Text = seq.Name,
                FontSize = 10
            };

            Canvas.SetLeft(label, x);
            Canvas.SetTop(label, canvasHeight - 25);
            ChartCanvas.Children.Add(label);

            TextBlock value = new TextBlock
            {
                Text = seq.Length.ToString(),
                FontSize = 10
            };

            Canvas.SetLeft(value, x);
            Canvas.SetTop(value, y - 18);
            ChartCanvas.Children.Add(value);
        }
    }
}