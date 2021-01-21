using Homework_1;
using System;

namespace Homework_1
{

    class Employee
    {
        protected string name;
        protected decimal salary;
        protected decimal bonus;

        public string Name()
        {
            return name;
        }

        public decimal Salary(decimal salary)
        {
            this.salary = salary;
            return this.salary;
            
        }

        public Employee(string name, decimal salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public virtual void SetBonus(decimal bonus)
        {
            this.bonus = bonus;
        }

        public decimal ToPay()
        {
            salary += bonus;
            return salary;
        }
    }

    class SalesPerson : Employee
    {
        protected int percent;

        public SalesPerson(string name, decimal salary, int percent)
            : base(name, salary) 
        {
            this.percent = percent;
        }

        public override void SetBonus(decimal bonus)
        {
            if(percent <= 100)
            {
                base.SetBonus(bonus);
            } 
            if (percent > 100 && percent <= 200)
            {
                base.SetBonus(bonus * 2);
            }
            if(percent > 200)
            {
                base.SetBonus(bonus * 3);
            }       
        }
    }

    class Manager : Employee
    {
        protected int quantity;

        public Manager(string name, decimal salary, int clientAmount)
            : base(name, salary)
        {
            quantity = clientAmount;
        }

        public override void SetBonus(decimal bonus)
        {
            if (quantity <= 100)
            {
                base.SetBonus(bonus);
            }
            if (quantity > 100 && quantity <= 150)
            {
                base.SetBonus(bonus + 500);
            }
            if (quantity > 150)
            {
                base.SetBonus(bonus + 1000);
            }
        }
    }

    class Company
    {
        protected Employee [] staff;

        public Company(Employee []  a)
        {
            staff = a;
        }

        public void GiveEverybodyBonus(decimal companyBonus)
        {
            for (int i = 0; i < staff.Length; i++)
            {
                staff[i].SetBonus(companyBonus);
            }   
        }

        public decimal TotalToPay()
        {
            decimal totalToPay = 0;
            for (int i = 0; i < staff.Length; i++)
            {
                totalToPay += staff[i].ToPay();
            }
            return totalToPay;
        }

        public string NameMaxSalary()
        {
            decimal maxSalary = 0;
            string resName = "";
            for (int i = 0; i < staff.Length; i++)
            {
                if (maxSalary <= staff[i].ToPay())
                {
                    maxSalary = staff[i].ToPay();
                    resName = staff[i].Name();
                }
            }
            return resName;
        }
    }



    public static class MainClass
    {
        public static int Main()
        {
            Employee a = new Employee("a", 50);
            SalesPerson b = new SalesPerson("b", 0, 20);
            Manager c = new Manager("c", 5, 500);
            Employee[] abc = { a, b, c };
            Company gg = new Company(abc);
            gg.GiveEverybodyBonus(100);
            Console.WriteLine("a.salary=" + a.ToPay());
            Console.WriteLine("b.salary=" + b.ToPay());
            Console.WriteLine("c.salary=" + c.ToPay());
            Console.WriteLine("total.salary="+ gg.TotalToPay());
            Console.WriteLine("best.worker=" + gg.NameMaxSalary());
            return 0;
        }
    }

}
