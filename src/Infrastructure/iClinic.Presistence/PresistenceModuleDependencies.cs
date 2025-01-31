using  iClinic.Presistence.Contract;
using  iClinic.Presistence.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace iClinic.Infrastructure
{
    public static class PresistenceModuleDependencies
    {
        public static IServiceCollection AddPresistenceModuleDependencies(this IServiceCollection services)
        {
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IClinicService, ClinicService>();
            services.AddTransient<IClinicDepartmentService, ClinicDepartmentService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IEmployeeScheduleService, EmployeeScheduleService>();
            services.AddTransient<IScheduleService, ScheduleService>();
            services.AddTransient<IAppointmentStatusService, AppointmentStatusService>();
            services.AddTransient<IPatientCaseService, PatientCaseService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IStatusHistoryService, StatusHistoryService>();
            services.AddTransient<IDocumentTypeService, DocumentTypeService>();
            services.AddTransient<IDocumentService, DocumentService>();
            return services;
        }
    }
}
