using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab7.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CountButton_Click(object? sender, RoutedEventArgs e)
    {
        string dna = DnaInput.Text ?? "";

        dna = dna.ToUpper()
                 .Replace(" ", "")
                 .Replace("\n", "")
                 .Replace("\r", "")
                 .Replace("\t", "");

        if (dna.Length < 4)
        {
            InfoText.Text = "Sekwencja musi miec co najmniej 4 znaki.";
            ResultBox.Text = "";
            return;
        }

        foreach (char znak in dna)
        {
            if (znak != 'A' && znak != 'C' && znak != 'G' && znak != 'T')
            {
                InfoText.Text = "Blad: sekwencja moze zawierac tylko litery A, C, G, T.";
                ResultBox.Text = "";
                return;
            }
        }

        Dictionary<string, int> wyniki = new Dictionary<string, int>();

        for (int i = 0; i <= dna.Length - 4; i++)
        {
            string fragment = dna.Substring(i, 4);

            if (wyniki.ContainsKey(fragment))
            {
                wyniki[fragment]++;
            }
            else
            {
                wyniki[fragment] = 1;
            }
        }

        StringBuilder tekst = new StringBuilder();

        foreach (var para in wyniki.OrderBy(x => x.Key))
        {
            tekst.AppendLine($"{para.Key} : {para.Value}");
        }

        InfoText.Text = $"Znaleziono {wyniki.Count} roznych sekwencji dlugosci 4.";
        ResultBox.Text = tekst.ToString();
    }
}