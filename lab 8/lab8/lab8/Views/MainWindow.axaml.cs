using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace lab8;

public partial class MainWindow : Window
{
    private readonly DatabaseManager databaseManager = new DatabaseManager();

    public MainWindow()
    {
        InitializeComponent();
        LoadEntries();
    }
    private void SaveButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            databaseManager.WriteData(
                ImieNazwiskoBox.Text ?? "",
                NumerAlbumuBox.Text ?? "",
                KierunekBox.Text ?? "",
                StopienBox.Text ?? "",
                SemestrBox.Text ?? "",
                TrybStudiowBox.Text ?? "",
                RokAkademickiBox.Text ?? "",
                PrzedmiotBox.Text ?? "",
                ProwadzacyBox.Text ?? "",
                TerminEgzaminuBox.Text ?? "",
                UzasadnienieBox.Text ?? "",
                DataZlozeniaBox.Text ?? "",
                AdresEmailBox.Text ?? "",
                TelefonBox.Text ?? "",
                PodpisBox.Text ?? ""
            );

            InfoText.Text = "Dane zostaly zapisane do bazy.";
            LoadEntries();
        }
        catch (Exception ex)
        {
            InfoText.Text = "Blad zapisu: " + ex.Message;
        }
    }

    private void ReadButton_Click(object? sender, RoutedEventArgs e)
    {
        LoadEntries();
        InfoText.Text = "Dane zostaly odczytane z bazy.";
    }

    private void ClearButton_Click(object? sender, RoutedEventArgs e)
    {
        ImieNazwiskoBox.Text = "";
        NumerAlbumuBox.Text = "";
        KierunekBox.Text = "";
        StopienBox.Text = "";
        SemestrBox.Text = "";
        TrybStudiowBox.Text = "";
        RokAkademickiBox.Text = "";
        PrzedmiotBox.Text = "";
        ProwadzacyBox.Text = "";
        TerminEgzaminuBox.Text = "";
        UzasadnienieBox.Text = "";
        DataZlozeniaBox.Text = "";
        AdresEmailBox.Text = "";
        TelefonBox.Text = "";
        PodpisBox.Text = "";

        InfoText.Text = "Formularz wyczyszczony.";
    }

    private void LoadEntries()
    {
        EntriesList.ItemsSource = databaseManager.ReadData();
    }
}
