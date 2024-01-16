// IMedicalRecordService.cs
namespace Hospital_Management_System
{
    public interface IMedicalRecordService
    {
        void StoreRecord(MedicalRecord medicalRecord);
        MedicalRecord RetrieveRecord(int patientId);
    }
}
