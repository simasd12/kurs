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
            this.name = name;
            this.salary = salary;
            this.percent = percent;
        }

        public override void SetBonus(decimal bonus)
        {
            if(percent <= 100)
            {
                this.bonus = bonus;
            } 
            if (percent > 100 && percent <= 200)
            {
                this.bonus = bonus*2;
            }
            if(percent > 200)
            {
                this.bonus = bonus*3;
            }       
        }
    }

    class Manager : Employee
    {
        protected int quantity;

        public Manager(string name, decimal salary, int clientAmount)
            : base(name, salary)
        {
            this.name = name;
            this.salary = salary;
            quantity = clientAmount;
        }

        public override void SetBonus(decimal bonus)
        {
            if (quantity <= 100)
            {
                this.bonus = bonus;
            }
            if (quantity > 100 && quantity <= 150)
            {
                this.bonus = bonus + 500;
            }
            if (quantity > 150)
            {
                this.bonus = bonus + 1000;
            }
        }
    }




    public static class MainClass
    {
        public static int Main()
        {
            SalesPerson a = new SalesPerson("ввв", 0, 20);
            a.SetBonus(10);
            Console.WriteLine("" + a.ToPay()) ;
            Manager b = new Manager("", 5, 500);
            b.SetBonus(0);
            Console.WriteLine("" + b.ToPay());
            Employee c = new Employee("123", 50);
            c.SetBonus(10);
            Console.WriteLine("" + c.ToPay());
            return 0;
        }
    }

}