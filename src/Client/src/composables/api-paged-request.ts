import type { DataTablePageEvent, DataTableSortEvent } from 'primevue/datatable'
import type { PagedReq, PagedRes } from '~/types/pagination'

export function useApiPagedReq<TReq, TRes>(action: (req?: TReq) => Promise<PagedRes<TRes>>) {
  type IRequest = TReq & PagedReq
  const request = ref<Partial<IRequest>>({})
  const response = ref<PagedRes<TRes>>()
  const loading = ref(false)
  const fetchRequest = async (params?: TReq): Promise<PagedRes<TRes>> => {
    loading.value = true
    const query = { ...params, ...request.value as TReq } as TReq
    const data = await action(query)
    response.value = data
    loading.value = false
    return data
  }
  const onPage = async (event: DataTablePageEvent) => {
    request.value = { ...request.value as any, page: event.page }
    await fetchRequest()
  }
  const onSort = async (event: DataTableSortEvent) => {
    request.value = { ...request.value as any, sortBy: event.sortField, descending: event.sortOrder === 1 }
    await fetchRequest()
  }
  const onFilterRequest = async () => {
    request.value = { ...request.value as any, page: 1 }
    await fetchRequest()
  }
  return { request, fetchRequest, onPage, onSort, loading, response, onFilterRequest }
}
