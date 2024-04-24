import type { Role } from '~/enums/role'

export interface GetUserRes {
  id: string
  name: string
  email: string
  role: Role
  roleDesc: string
}
export interface ChangePasswordReq {
  oldPassword: string
  newPassword: string
  confirmPassword: string
}
export interface UserUpdateProfileReq {
  name: string
  email: string
}
export const authApi = {
  async getUser(): Promise<GetUserRes> {
    const res = await api.get('/user')
    return res.data
  },
  async changePassword(req: ChangePasswordReq) {
    await api.put('/change-password', req)
  },
  async updateProfile(req: UserUpdateProfileReq) {
    await api.put('/update-profile', req)
  },
}
