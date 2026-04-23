using ConsAppPayment;

IPayment ppal = new PaypalPayment();
ppal.Paga(12);

IPayment satp = new SatispayPayment();
satp.Paga(45);