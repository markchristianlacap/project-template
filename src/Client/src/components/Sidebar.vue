<script setup lang="ts">
import type { MenuItem } from 'primevue/menuitem'

const userStore = useUserStore()
const toast = useToast()
const router = useRouter()
const menu = ref<any>()
const { isMobile } = useScreenResolutions()
const items = ref<MenuItem[]>([
  {
    label: 'Dashboard',
    url: '/user',
    icon: 'pi pi-home',
  },
  {
    label: 'Users',
    url: '/users',
    icon: 'pi pi-users',
  },
  {
    label: 'Logout',
    icon: 'pi pi-sign-out',
    command: async () => {
      await userStore.logout()
      toast.add({ severity: 'info', detail: 'Logout successfully' })
      router.push('/')
    },
  },
])
function toggle(e: any) {
  menu.value.toggle(e)
}
</script>

<template>
  <Button v-if="isMobile" type="button" icon="pi pi-bars" aria-isMobile="true" aria-controls="overlay_menu" @click="toggle" />
  <Menu ref="menu" :model="items" :popup="isMobile" />
</template>
