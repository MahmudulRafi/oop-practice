using Practice_13.Models;

try
{
    var prescriptionCollection = new PrescriptionCollection();

    var patient = new Patient(101, "Mr. X");

    var medication1 = new Medication("Napa 500", "Antibiotics");

    medication1.AddContradictoryMedication("Statins");

    var medication2 = new Medication("Amox 50", "Muscle Relaxants");

    medication2.AddContradictoryMedication("CNS Depressants");

    var medication3 = new Medication("Relya 20", "Anti-Inflammatories");

    medication3.AddContradictoryMedication("Anticoagulants");

    var medication4 = new Medication("Belas 50", "Statins");

    var prescription1 = patient.PrescribeMedication(medication1);

    prescriptionCollection.AddPrescription(prescription1);

    var prescription2 = patient.PrescribeMedication(medication4);

    prescriptionCollection.AddPrescription(prescription2);

    var prescriptions = prescriptionCollection.GetPatientPrescriptions(patient);

    foreach (var prescription in prescriptions)
    {
        Console.WriteLine($"Patient {prescription.Patient.Name} has {prescription.Medication.Name} of type {prescription.Medication.Type}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}