using ChainOfResponsibility_Design_Pattern.DAL;
using ChainOfResponsibility_Design_Pattern.DAL.Entities;

namespace ChainOfResponsibility_Design_Pattern.ChainOfResponsibility
{
    public class AreaDirector:Employee
    {
        Context context = new Context();
        public override void ProcessRequest(WithDraw req)
        {
            if (req.Amount <= 150000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.EmployeeTitle = this.GetType().Name;
                customerProcess.EmployeeName = "Gizem Öztürk";
                customerProcess.Description = "Para Çekme İşlemi Onaylandı, müşteriye ödeme yapıldı";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {

                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.EmployeeTitle = this.GetType().Name;
                customerProcess.EmployeeName = "Gizem Öztürk";
                customerProcess.Description = "Limit Günlük Para Çekme Tutarı Aşıldığı İçin İşlem Onaylanmadı";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
