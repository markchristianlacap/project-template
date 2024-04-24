import PrimeVue from 'primevue/config'
import ToastService from 'primevue/toastservice'
import Tooltip from 'primevue/tooltip'
import ConfirmationService from 'primevue/confirmationservice'
import type { UserModule } from '~/types'
import Wind from '~/presets/wind' // import preset
// Setup PrimeVue
// https://primevue.org/vite
export const install: UserModule = ({ app }) => {
  app.use(PrimeVue, {
    unstyled: true,
    pt: Wind,
    ptOptions: {
      mergeProps: true,
    },
  })
  app.directive('tooltip', Tooltip)
  app.use(ToastService)
  app.use(ConfirmationService)
}
