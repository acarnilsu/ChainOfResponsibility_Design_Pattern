using ChainOfResponsibility_Design_Pattern.DAL;
using ChainOfResponsibility_Design_Pattern.DAL.Entities;

namespace ChainOfResponsibility_Design_Pattern.ChainOfResponsibility
{
    public class Treasurer:Employee
    {
        Context context = new Context();
        public override void ProcessRequest(WithDraw req)
        {
            if (req.Amount <= 40000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.EmployeeTitle = this.GetType().Name;
                customerProcess.EmployeeName = "Ali Yıldız";
                customerProcess.Description = "Para Çekme İşlemi Onaylandı, müşteriye ödeme yapıldı";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {

                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.EmployeeTitle = this.GetType().Name;
                customerProcess.EmployeeName = "Ali Yıldız";
                customerProcess.Description = "Para Çekme Tutar Talebi Günlük İşlemi aştığı için talep bir üst personele yönlendirildi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
