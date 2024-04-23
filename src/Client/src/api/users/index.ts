import type { Role } from '~/enums/role'
import type { PagedReq, PagedRes } from '~/types/pagination'

export interface UserModel {
  name: string
  email: string
  role: Role
  isActive: boolean
}
export interface UserRowRes extends UserModel {
  id: string
  roleDesc: string
  createdAt: string
  updatedAt: string
}

export interface UserPagedReq extends PagedReq {
  search: string | null
}

export interface UserStoreReq extends UserModel {
  password: string
}

export interface UserStoreRes extends UserStoreReq {
  id: string
}
export interface UserUpdateReq extends UserModel {

}

export interface UserUpdateRes extends UserUpdateReq {

}

export const usersApi = {
  async getPaged(req?: UserPagedReq): Promise<PagedRes<UserRowRes>> {
    const { data } = await api.get('/users', { params: req })
    return data
  },
  async store(req: UserStoreReq): Promise<UserStoreRes> {
    const { data } = await api.post('/users', req)
    return data
  },
  async update(id: string, req: UserUpdateReq): Promise<UserUpdateRes> {
    const { data } = await api.put(`/users/${id}`, req)
    return data
  },
}
