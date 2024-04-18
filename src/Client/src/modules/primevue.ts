import PrimeVue from 'primevue/config'
import ToastService from 'primevue/toastservice'
import type { UserModule } from '~/types'
import Lara from '~/presets/lara' // import preset
// Setup PrimeVue
// https://primevue.org/vite
export const install: UserModule = ({ app }) => {
  app.use(PrimeVue, {
    unstyled: true,
    pt: Lara,
    ptOptions: {
      mergeProps: true,
    },
  })
  app.use(ToastService)
}
