import { defineStore } from 'pinia'

export interface LoginReq {
  email: string
  password: string
}
export interface GetUserRes {
  id: string
  name: string
  email: string
}
export const useUserStore = defineStore('user', () => {
  const user = ref<GetUserRes | null>(null)
  async function fetchUser(): Promise<GetUserRes | null> {
    try {
      const { data } = await api.get('/user')
      user.value = data
      return Promise.resolve(data)
    }
    catch {
      return null
    }
  }
  const login = async (form: LoginReq) => {
    await api.post('/login', form)
    await fetchUser()
    return Promise.resolve()
  }
  const logout = async () => {
    await api.post('/logout')
    user.value = null
    return Promise.resolve()
  }
  return {
    user,
    fetchUser,
    logout,
    login,
  }
})
