using System;
using System.Collections.Generic;

namespace DocumentHierarchy
{
    // Абстрактний базовий клас Document
    public abstract class Document
    {
        // Захищені поля
        protected string number;
        protected DateTime date;
        protected string description;

        // Конструктор за замовчуванням
        public Document()
        {
            number = "Не вказано";
            date = DateTime.Now;
            description = "Не вказано";
            Console.WriteLine("Викликано конструктор за замовчуванням класу Document");
        }

        // Конструктор з параметрами
        public Document(string number, DateTime date, string description)
        {
            this.number = number;
            this.date = date;
            this.description = description;
            Console.WriteLine("Викликано конструктор з параметрами класу Document");
        }

        // Конструктор копіювання
        public Document(Document doc)
        {
            this.number = doc.number;
            this.date = doc.date;
            this.description = doc.description;
            Console.WriteLine("Викликано конструктор копіювання класу Document");
        }

        // Властивості
        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // Абстрактний метод
        public abstract decimal CalculateTotal();

        // Віртуальний метод
        public virtual void Show()
        {
            Console.WriteLine($"Номер документа: {number}");
            Console.WriteLine($"Дата: {date.ToShortDateString()}");
            Console.WriteLine($"Опис: {description}");
        }

        // Деструктор
        ~Document()
        {
            Console.WriteLine($"Викликано деструктор класу Document для документа {number}");
        }
    }

    // Похідний клас - Квитанція
    public class Receipt : Document
    {
        // Додаткові поля
        private string personName;
        private decimal amount;

        // Конструктор за замовчуванням
        public Receipt() : base()
        {
            personName = "Не вказано";
            amount = 0;
            Console.WriteLine("Викликано конструктор за замовчуванням класу Receipt");
        }

        // Конструктор з параметрами
        public Receipt(string number, DateTime date, string description, string personName, decimal amount)
            : base(number, date, description)
        {
            this.personName = personName;
            this.amount = amount;
            Console.WriteLine("Викликано конструктор з параметрами класу Receipt");
        }

        // Конструктор копіювання
        public Receipt(Receipt receipt) : base(receipt)
        {
            this.personName = receipt.personName;
            this.amount = receipt.amount;
            Console.WriteLine("Викликано конструктор копіювання класу Receipt");
        }

        // Властивості
        public string PersonName
        {
            get { return personName; }
            set { personName = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        // Реалізація абстрактного методу
        public override decimal CalculateTotal()
        {
            return amount;
        }

        // Перевизначення віртуального методу
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Особа: {personName}");
            Console.WriteLine($"Сума: {amount:C}");
        }

        // Деструктор
        ~Receipt()
        {
            Console.WriteLine($"Викликано деструктор класу Receipt для квитанції {number}");
        }
    }

    // Похідний клас - Накладна
    public class Invoice : Document
    {
        // Додаткові поля
        private string supplier;
        private string receiver;
        private List<InvoiceItem> items;

        // Конструктор за замовчуванням
        public Invoice() : base()
        {
            supplier = "Не вказано";
            receiver = "Не вказано";
            items = new List<InvoiceItem>();
            Console.WriteLine("Викликано конструктор за замовчуванням класу Invoice");
        }

        // Конструктор з параметрами
        public Invoice(string number, DateTime date, string description, string supplier, string receiver)
            : base(number, date, description)
        {
            this.supplier = supplier;
            this.receiver = receiver;
            this.items = new List<InvoiceItem>();
            Console.WriteLine("Викликано конструктор з параметрами класу Invoice");
        }

        // Конструктор копіювання
        public Invoice(Invoice invoice) : base(invoice)
        {
            this.supplier = invoice.supplier;
            this.receiver = invoice.receiver;
            this.items = new List<InvoiceItem>(invoice.items);
            Console.WriteLine("Викликано конструктор копіювання класу Invoice");
        }

        // Властивості
        public string Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }

        public string Receiver
        {
            get { return receiver; }
            set { receiver = value; }
        }

        // Методи
        public void AddItem(string name, decimal price, int quantity)
        {
            items.Add(new InvoiceItem(name, price, quantity));
        }

        // Реалізація абстрактного методу
        public override decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.Price * item.Quantity;
            }
            return total;
        }

        // Перевизначення віртуального методу
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Постачальник: {supplier}");
            Console.WriteLine($"Отримувач: {receiver}");
            Console.WriteLine("Список товарів:");

            foreach (var item in items)
            {
                Console.WriteLine($"  - {item.Name}: {item.Price:C} x {item.Quantity} = {item.Price * item.Quantity:C}");
            }
        }

        // Індексатор для доступу до елементів накладної
        public InvoiceItem this[int index]
        {
            get
            {
                if (index >= 0 && index < items.Count)
                    return items[index];
                throw new IndexOutOfRangeException("Індекс за межами діапазону");
            }
        }

        // Деструктор
        ~Invoice()
        {
            Console.WriteLine($"Викликано деструктор класу Invoice для накладної {number}");
        }
    }

    // Клас для елементів накладної
    public class InvoiceItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public InvoiceItem(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }

    // Похідний клас - Рахунок
    public class Bill : Document
    {
        // Додаткові поля
        private string clientName;
        private string serviceDescription;
        private decimal serviceAmount;
        private decimal taxRate;

        // Конструктор за замовчуванням
        public Bill() : base()
        {
            clientName = "Не вказано";
            serviceDescription = "Не вказано";
            serviceAmount = 0;
            taxRate = 0;
            Console.WriteLine("Викликано конструктор за замовчуванням класу Bill");
        }

        // Конструктор з параметрами
        public Bill(string number, DateTime date, string description, string clientName,
                   string serviceDescription, decimal serviceAmount, decimal taxRate)
            : base(number, date, description)
        {
            this.clientName = clientName;
            this.serviceDescription = serviceDescription;
            this.serviceAmount = serviceAmount;
            this.taxRate = taxRate;
            Console.WriteLine("Викликано конструктор з параметрами класу Bill");
        }

        // Конструктор копіювання
        public Bill(Bill bill) : base(bill)
        {
            this.clientName = bill.clientName;
            this.serviceDescription = bill.serviceDescription;
            this.serviceAmount = bill.serviceAmount;
            this.taxRate = bill.taxRate;
            Console.WriteLine("Викликано конструктор копіювання класу Bill");
        }

        // Властивості
        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }

        public string ServiceDescription
        {
            get { return serviceDescription; }
            set { serviceDescription = value; }
        }

        public decimal ServiceAmount
        {
            get { return serviceAmount; }
            set { serviceAmount = value; }
        }

        public decimal TaxRate
        {
            get { return taxRate; }
            set { taxRate = value; }
        }

        // Методи
        private decimal CalculateTax()
        {
            return serviceAmount * taxRate / 100;
        }

        // Реалізація абстрактного методу
        public override decimal CalculateTotal()
        {
            return serviceAmount + CalculateTax();
        }

        // Перевизначення віртуального методу
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Клієнт: {clientName}");
            Console.WriteLine($"Опис послуги: {serviceDescription}");
            Console.WriteLine($"Сума послуги: {serviceAmount:C}");
            Console.WriteLine($"Ставка податку: {taxRate}%");
            Console.WriteLine($"Сума податку: {CalculateTax():C}");
        }

        // Перевантаження оператора +
        public static Bill operator +(Bill b1, Bill b2)
        {
            return new Bill(
                b1.Number + "+" + b2.Number,
                DateTime.Now,
                "Об'єднаний рахунок",
                b1.ClientName,
                b1.ServiceDescription + " & " + b2.ServiceDescription,
                b1.ServiceAmount + b2.ServiceAmount,
                (b1.TaxRate + b2.TaxRate) / 2 // середня ставка податку
            );
        }

        // Деструктор
        ~Bill()
        {
            Console.WriteLine($"Викликано деструктор класу Bill для рахунку {number}");
        }
    }
}