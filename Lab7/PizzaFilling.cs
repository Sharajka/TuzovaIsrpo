using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class PizzaFilling
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public static List<PizzaFilling> GenerateTestData()
        {
            return new List<PizzaFilling>()
            {
                new PizzaFilling()
                {
                    Name = "Моцарелла",
                    Price = 30
                },
                new PizzaFilling()
                {
                    Name = "Ветчина",
                    Price = 40
                },
                new PizzaFilling()
                {
                    Name = "Грибы",
                    Price = 20
                },
                new PizzaFilling()
                {
                    Name = "Огурцы",
                    Price = 10
                },
                new PizzaFilling()
                {
                    Name = "Индейка",
                    Price = 70
                },
                new PizzaFilling()
                {
                    Name = "Оливки",
                    Price = 15
                },
                new PizzaFilling()
                {
                    Name = "Салями",
                    Price = 12
                },
                new PizzaFilling()
                {
                    Name = "Помидоры",
                    Price = 6
                },
                new PizzaFilling()
                {
                    Name = "Ананас",
                    Price = 6000000000
                }
            };
        }
    }
}
