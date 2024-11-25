using GestionBoutiqueC.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionBoutiqueC.Core{

    public class PaginationDetteModel : PaginationModel<Dette>
    {
        public Client Client { get; set; }
        protected PaginationDetteModel(List<Dette> items, int totalItems, int pageSize, int currentPage, Client client)
        : base(items, totalItems, pageSize, currentPage)
        {
            Client = client;
        }

        public static async Task<PaginationDetteModel> PaginateDette(IQueryable<Dette> data, int pageSize, int currentPage, Client client)
        {
            
            var pageModel = await PaginationModel<Dette>.Paginate(data, pageSize, currentPage);
            return new PaginationDetteModel( pageModel.Items, pageModel.TotalItems, pageModel.PageSize, pageModel.CurrentPage, client);
        }
    }
}