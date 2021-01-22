using System;

namespace Inheritance
{

    class Employee
    {
        protected string name;
        protected decimal salary;
        protected decimal bonus;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return salary;
            }

            set
            {
                salary = value;
            }
        }

        public Employee(string name, decimal salary)
        {
            this.name = name;
            Salary = salary;
        }

        public virtual void SetBonus(decimal bonus)
        {
            this.bonus = bonus;
        }

        public decimal ToPay()
        {
            Salary += bonus;
            return Salary;
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
        protected Employee [] employees;

        public Company(Employee []  a)
        {
            employees = a;
        }

        public void GiveEverybodyBonus(decimal companyBonus)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                employees[i].SetBonus(companyBonus);
            }   
        }

        public decimal TotalToPay()
        {
            decimal totalToPay = 0;
            for (int i = 0; i < employees.Length; i++)
            {
                totalToPay += employees[i].ToPay();
            }
            return totalToPay;
        }

        public string NameMaxSalary()
        {
            decimal maxSalary = 0;
            string resName = "";
            for (int i = 0; i < employees.Length; i++)
            {
                if (maxSalary <= employees[i].ToPay())
                {
                    maxSalary = employees[i].ToPay();
                    resName = employees[i].Name;
                }
            }
            return resName;
        }
    }

}
