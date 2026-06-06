// Case Study 1: Hospital Management System
// Scenario
// A hospital application manages:
// •	Patient Registration
// •	Doctor Consultation
// •	Billing
// •	Notifications
// •	Medical Reports
// ________________________________________
// Activity Questions
// 1.	Add WhatsApp notification support.
// 2.	Add Credit Card payment support.
// 3.	Create a MedicalReportService following SRP.

using System;

class HospitalManagementSystem
{
    static void Main(string[] args)
    {
        Console.WriteLine("----- HOSPITAL MANAGEMENT SYSTEM -----");

        Console.WriteLine("\n1. Register Patient");
        Console.Write("Enter Patient Name: ");
        String name = Console.ReadLine();
        Console.Write("Enter Patient Age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Patient Registered Successfully\n");

        Console.WriteLine("2. Doctor Consultation");
        Console.Write("Enter symptoms: ");
        String symptoms = Console.ReadLine();
        Console.WriteLine($"Doctor Consultation Done\nDiagnosis: {symptoms}\n");

        Console.WriteLine("3. Generate Medical Report");
        Console.WriteLine("----- MEDICAL REPORT -----");
        Console.WriteLine($"Patient Name: {name}");
        Console.WriteLine($"Diagnosis: {symptoms}\n");

        Console.WriteLine("4. Billing (Payment)");
        Console.WriteLine("Total Amount: ₹500");
        Console.WriteLine("1. Debit Card");
        Console.WriteLine("2. Credit Card");
        Console.WriteLine("3. Cash");
        Console.Write("Choose Payment Method(Enter number): ");
        int pay = Convert.ToInt32(Console.ReadLine());
        if(pay==1)
        {
            IPaymentService payment = new DebitCardPayment();
            payment.Pay(500);
        } else if(pay==2)
        {
            IPaymentService payment = new CreditCardPayment();
            payment.Pay(500);
        } else if(pay==3)
        {
            IPaymentService payment = new CashPayment();
            payment.Pay(500);
        } else
        {
            Console.WriteLine("Payment Failed. Try Again.");
            return;
        }

        Console.WriteLine("\n5. Send Notification");
        Console.WriteLine("1. Message");
        Console.WriteLine("2. WhatsApp");
        Console.Write("Choose notification Method(Enter number): ");
        int notf = Convert.ToInt32(Console.ReadLine());
        if(notf==1)
        {
            INotificationService notification = new MessageNotification();
            notification.Send();
        } else if(notf==2)
        {
            INotificationService notification = new WhatsAppNotification();
            notification.Send();
        } else
        {
            INotificationService notification = new MessageNotification();
            notification.Send();
            notification = new WhatsAppNotification();
            notification.Send();
        }

        Console.WriteLine("\nThanks. Visit Again...");
    }
}
