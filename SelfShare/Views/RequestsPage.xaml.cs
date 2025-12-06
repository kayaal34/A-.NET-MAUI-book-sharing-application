using SelfShare.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace SelfShare.Views;

public partial class RequestsPage : ContentPage
{
    // Verileri tutacak ana liste
    List<RequestModel> _allRequests = new List<RequestModel>();

    public RequestsPage()
    {
        InitializeComponent();
    }

    // Sayfa her ekrana geldiğinde çalışır
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await RefreshData(); // Verileri yükle
    }

    // Gelen (Incoming) butonu
    private void OnIncomingClicked(object sender, EventArgs e)
    {
        UpdateListView(true); // Incoming göster
    }

    // Giden (Outgoing) butonu
    private void OnOutgoingClicked(object sender, EventArgs e)
    {
        UpdateListView(false); // Outgoing göster
    }

    // --- EKSİK OLAN KISIMLAR BURADAYDI ---

    // KABUL ETME BUTONU
    private async void OnAcceptClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var request = (RequestModel)button.CommandParameter;

        if (request == null) return;

        bool isConfirmed = await DisplayAlert("Onay", $"{request.Title} isteğini kabul etmek istiyor musun?", "Evet", "Hayır");

        if (isConfirmed)
        {
            var repo = new RequestRepository();

            // 1. Durumu güncelle
            request.Status = "Accepted";

            // 2. Veritabanına yaz
            await repo.UpdateRequestAsync(request);

            // 3. Listeyi yenile
            await RefreshData();

            await DisplayAlert("Süper", "İstek kabul edildi! Kitabı teslim edebilirsin.", "Tamam");
        }
    }

    // REDDETME BUTONU
    private async void OnDeclineClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var request = (RequestModel)button.CommandParameter;

        if (request == null) return;

        bool isConfirmed = await DisplayAlert("Red", "Bu isteği reddetmek ve silmek istediğine emin misin?", "Sil", "Vazgeç");

        if (isConfirmed)
        {
            var repo = new RequestRepository();

            // 1. Veritabanından sil
            await repo.DeleteRequestAsync(request);

            // 2. Listeyi yenile
            await RefreshData();
        }
    }

    // YARDIMCI METOD: Listeyi veritabanından tekrar çekip günceller
    private async Task RefreshData()
    {
        var repo = new RequestRepository();
        _allRequests = await repo.GetRequestsAsync();

        // SAHTE VERİ KONTROLÜ (Test için)
        bool newDataAdded = false;
        if (!_allRequests.Any(r => r.IsIncoming == true))
        {
            await repo.AddRequestAsync(new RequestModel { Title = "Calculus 101", UserName = "Liam Harper", ImageUrl = "war.png", Status = "Pending", IsIncoming = true });
            await repo.AddRequestAsync(new RequestModel { Title = "Organic Chemistry", UserName = "Olivia Bennett", ImageUrl = "sefiller.png", Status = "Pending", IsIncoming = true });
            newDataAdded = true;
        }

        if (newDataAdded)
        {
            _allRequests = await repo.GetRequestsAsync();
        }

        // Varsayılan olarak Incoming'i göster
        UpdateListView(true);
    }

    // Listeyi güncelleme ve renkleri ayarlama
    private void UpdateListView(bool showIncoming)
    {
        if (showIncoming)
        {
            BtnIncoming.BackgroundColor = Color.FromArgb("#4A90E2");
            BtnIncoming.TextColor = Colors.White;
            BtnOutgoing.BackgroundColor = Colors.Transparent;
            BtnOutgoing.TextColor = Color.FromArgb("#666666");

            RequestsCollection.ItemsSource = _allRequests.Where(r => r.IsIncoming == true).ToList();
        }
        else
        {
            BtnOutgoing.BackgroundColor = Color.FromArgb("#4A90E2");
            BtnOutgoing.TextColor = Colors.White;
            BtnIncoming.BackgroundColor = Colors.Transparent;
            BtnIncoming.TextColor = Color.FromArgb("#666666");

            RequestsCollection.ItemsSource = _allRequests.Where(r => r.IsIncoming == false).ToList();
        }
    }
}