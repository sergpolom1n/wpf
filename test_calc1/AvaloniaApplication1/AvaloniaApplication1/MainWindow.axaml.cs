using System;
using System.Data;
using Avalonia.Controls;
using Avalonia.Interactivity;




namespace AvaloniaApplication1;

public partial class MainWindow : Window
{
    private string _input = string.Empty;
    
    public MainWindow()
    {
        InitializeComponent();
    }
    private void OnButtonClick(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            _input += button.Content.ToString();
            TextLabel.Text = _input;
        }
    }

    private void ClearInput(object sender, RoutedEventArgs e)
    {
        _input = string.Empty;
        TextLabel.Text = _input;
    }

    private void CalculateResult(object sender, RoutedEventArgs e)
    {
        try
        {
            var result = new DataTable().Compute(_input, null);
            TextLabel.Text = result.ToString();
            _input = string.Empty;
        }
        catch (EvaluateException ex)
        {
            TextLabel.Text = "Ошибка в выражении: " + ex.Message;
            Console.WriteLine("sueta");
        }
        catch (Exception ex)
        {
            TextLabel.Text = "Ошибка в выражении";
            Console.WriteLine(ex.Message);
        }
        
        
    }

}