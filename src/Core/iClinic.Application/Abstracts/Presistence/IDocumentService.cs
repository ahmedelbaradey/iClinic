﻿using iClinic.Domain.Entities;

namespace  iClinic.Application.Abstracts.Presistence
{
    public interface IDocumentService
    {
        public Task<bool> CreateDocumentAsync(Document document);
        public Task<bool> EditDocumentAsync(Document document);
        public Task<bool> DeleteDocumentAsync(Document document);
        public Task<List<Document>> GetDocumentListAsync();
        public Task<Document> GetDocumentByIdAsync(int Id);
        public Task<bool> IsDocumentExistByIdAsync(int Id);
        public IQueryable<Document> FilterDocumentPaginatedQuerable(string? doctorName = null, string? typeName = null);
    }
}
