export interface ChangePasswordReq {
  oldPassword: string
  newPassword: string
  confirmPassword: string
}
export const authApi = {
  async changePassword(req: ChangePasswordReq) {
    await api.put('/change-password', req)
  },
}
