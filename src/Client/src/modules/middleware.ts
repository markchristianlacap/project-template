import type { UserModule } from '~/types'

export const install: UserModule = ({ router }) => {
  router.beforeEach(async (to, from) => {
    if (to.meta.auth === false || to.meta.layout === 404)
      return
    const store = useUserStore()
    const redirect = to.query.redirect
    if (!store.user)
      await store.fetchUser()
    switch (to.meta.auth) {
      case 'guest':
        if (store.user !== null)
          return { path: redirect || '/user' }
        return
      default:
        if (store.user === null) {
          return {
            path: '/',
            query: { redirect: to.fullPath, from: from.fullPath },
          }
        }
        break
    }
  })
}
