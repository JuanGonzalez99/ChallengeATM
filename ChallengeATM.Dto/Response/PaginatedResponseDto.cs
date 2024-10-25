namespace ChallengeATM.Dto.Response
{
    /// <summary>
    /// Resultado paginado de una consulta
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="items">Elementos con una cantidad no superior a <paramref name="pageSize"/></param>
    /// <param name="cantidadTotal">Cantidad total de elementos</param>
    /// <param name="pageNumber">Número de página</param>
    /// <param name="pageSize">Tamaño de la página</param>
    public class PaginatedResponseDto<TItem>(List<TItem> items, int cantidadTotal, int pageNumber, int pageSize)
    {
        /// <summary>
        /// Elementos con una cantidad no superior al PageSize
        /// </summary>
        public List<TItem> Items { get; set; } = items;

        /// <summary>
        /// Cantidad total de elementos
        /// </summary>
        public int TotalItems { get; set; } = cantidadTotal;

        /// <summary>
        /// Número de página actual
        /// </summary>
        public int PageNumber { get; set; } = pageNumber;

        /// <summary>
        /// Tamaño de la página
        /// </summary>
        public int PageSize { get; set; } = pageSize;

        /// <summary>
        /// Cantidad total de páginas
        /// </summary>
        public int TotalPages { get; set; } = (int)Math.Ceiling((decimal)cantidadTotal / pageSize);
    }
}
