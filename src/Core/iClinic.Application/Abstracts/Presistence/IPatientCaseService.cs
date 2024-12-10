using iClinic.Domain.Entities;

namespace  iClinic.Application.Abstracts.Presistence
{
    public interface IPatientCaseService
    {
        public Task<bool> AddPatientCaseAsync(PatientCase patientCase);
        public Task<bool> UpdatePatientCaseAsync(PatientCase patientCase);
        public Task<bool> DeletePatientCaseAsync(PatientCase patientCase);
        public Task<List<PatientCase>> GetPatientCaseListAsync();
        public Task<PatientCase> GetPatientCaseByIdAsync(int Id);
        public Task<bool> IsPatientCaseExistById(int Id);
        public IQueryable<PatientCase> FilterPatientCasePaginatedQuerable(string? search = null);
    }
}
