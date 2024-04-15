<script setup lang="ts">
import type { MenuItem } from 'primevue/menuitem'

const userStore = useUserStore()
const toast = useToast()
const router = useRouter()
const items = ref<MenuItem[]>([
  {
    label: 'Dashboard',
    url: '/user',
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
</script>

<template>
  <Menu :model="items" class="mt-5 ml-5" />
</template>
