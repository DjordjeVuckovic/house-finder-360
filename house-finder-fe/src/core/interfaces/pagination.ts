export interface Pagination {
    currentPage: number,
    pageSize: number
}
export interface PaginationResponse<T> {
    pagination: PaginationInfo;
    data: T[]
}
export interface PaginationInfo {
    currentPage: number,
    pageSize : number,
    totalItems: number,
    totalPages: number
}