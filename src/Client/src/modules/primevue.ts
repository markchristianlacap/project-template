import PrimeVue from 'primevue/config'
import ToastService from 'primevue/toastservice'
import type { UserModule } from '~/types'
import Wind from '~/presets/wind' // import preset
// Setup PrimeVue
// https://primevue.org/vite
export const install: UserModule = ({ app }) => {
  app.use(PrimeVue, {
    unstyled: true,
    pt: Wind,
  })
  app.use(ToastService)
}
