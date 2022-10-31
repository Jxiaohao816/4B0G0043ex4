using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _20221023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string takeout;
        Dictionary<string, int> foods = new Dictionary<string, int>();
        public MainWindow()
        {
            InitializeComponent();
            AddNewFood(foods);
        }
        private void AddNewFood(Dictionary<string, int> myfood)
        {
            myfood.Add("咖啡大杯", 60);
            myfood.Add("咖啡小杯", 50);
            myfood.Add("紅茶大杯", 30);
            myfood.Add("紅茶小杯", 20);
            myfood.Add("綠茶大杯", 25);
            myfood.Add("綠茶小杯", 20);

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TB1.Text = "";
            var targetTextBox = new[] { BM1, BM2, MG1, MG2, DB1, DB2 };
            bool success = true;
            var count = new[] { 1, 1, 1, 1, 1, 1 };
            int money = 0;
            for (int i = 0; i <= 5; i++)
            {
                success = success && (int.TryParse(targetTextBox[i].Text, out count[i]) || targetTextBox[i].Text == "");

            }
            if (!success) MessageBox.Show("請輸入整數", "輸入錯誤");

            

            else if (count[0] < 0 && count[1] < 0 && count[2] < 0 && count[3] < 0 && count[4] < 0 && count[5] < 0) MessageBox.Show("請輸入正整數", "輸入錯誤");
            else
            {
                TB1.Text += $"您要 {takeout} 飲料,訂單清單如下:\n";
                for (int i = 0; i <= 5; i++)
                {
                    
                    StackPanel targetStackPanel = targetTextBox[i].Parent as StackPanel;
                    Label targetLabel = targetStackPanel.Children[0] as Label;
                    string foodItem = targetLabel.Content.ToString();
                    if (count[i] != 0)
                    {
                        TB1.Text = TB1.Text + $"{foodItem}X{count[i]}，每份{foods[foodItem]}元，總共{foods[foodItem] * count[i]}元\n";
                        TB1.Text = TB1.Text + "-------------\n";
                    }
                    money += count[i] * foods[foodItem];
                }
                if (money > 500)
                    money = money / 100 * 80;
                else if (money > 300)
                    money = money / 100 * 85;
                else if (money > 200)
                    money = money / 100 * 90;
                TB1.Text = TB1.Text + $"打折後小計：{money}元\n";

            }
        }

    }
}

