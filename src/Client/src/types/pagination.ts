export interface PagedReq {
  page: number | null
  rowsPerPage: number | null
  sortBy: string | null
  descending: boolean | null
}

export interface PagedRes<T> {
  currentPage: number
  pageCount: number
  rowsPerPage: number
  rowsCount: number
  rows: T[]
}
