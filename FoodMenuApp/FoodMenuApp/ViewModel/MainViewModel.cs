using FoodMenuApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FoodMenuApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {  
            Orders = new ObservableCollection<Food>();
            Foods = GetFoods();
        }
        
        public int OrderCount => Orders.Sum(x => x.Count);
        public float TotalPrice => Orders.Sum(x => x.Price* x.Count);

    
        private ObservableCollection<Food> foods;
        public ObservableCollection<Food> Foods
        {
            get { return foods; }
            set
            {
                foods = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Food> orders;
        public ObservableCollection<Food> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(OrderCount));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }


        private ObservableCollection<Food> GetFoods()
        {
            return new ObservableCollection<Food>
            {
                new Food{ Name = "Đây Là Tên Món Ăn 1", Image = "anh2.png", Price = 50000f, Description = "Đây là phần mô tả món ăn, bao gồm cách chế biến và các nguyên liệu của nó, phần này chưa được mô tả !!!"},
                new Food{ Name = "Đây Là Tên Món Ăn 2", Image = "anh8.png", Price = 100000f, Description = "Đây là phần mô tả món ăn, bao gồm cách chế biến và các nguyên liệu của nó, phần này chưa được mô tả !!!"},
                new Food{ Name = "Đây Là Tên Món Ăn 3", Image = "anh3.png", Price = 150000f, Description = "Đây là phần mô tả món ăn, bao gồm cách chế biến và các nguyên liệu của nó, phần này chưa được mô tả !!!"},
                new Food{ Name = "Đây Là Tên Món Ăn 4", Image = "anh9.png", Price = 200000f, Description = "Đây là phần mô tả món ăn, bao gồm cách chế biến và các nguyên liệu của nó, phần này chưa được mô tả !!!"},
                new Food{ Name = "Đây Là Tên Món Ăn 5", Image = "anh1.png", Price = 300000f, Description = "Đây là phần mô tả món ăn, bao gồm cách chế biến và các nguyên liệu của nó, phần này chưa được mô tả !!!"},
                new Food{ Name = "Đây Là Tên Món Ăn 6", Image = "anh4.png", Price = 300000f, Description = "Đây là phần mô tả món ăn, bao gồm cách chế biến và các nguyên liệu của nó, phần này chưa được mô tả !!!"},
               
            };
        }


        public void AddOrder(Food item)
        {
            if (item != null)
            {
                Orders.Add(item);
                OnPropertyChanged(nameof(OrderCount));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }
        public void RemoveOrder(Food item)
        {
            if (item != null)
            {
                Orders.Remove(item);
                OnPropertyChanged(nameof(OrderCount));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public void Load(Food item)
        {   if(item.Count !=0)
            Orders[Orders.IndexOf(item)] = item; 
            OnPropertyChanged(nameof(item));
            OnPropertyChanged(nameof(OrderCount));
            OnPropertyChanged(nameof(TotalPrice));
            
        }
    }
}
