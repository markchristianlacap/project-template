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
    route: '/user',
    icon: 'pi pi-home',
  },
  {
    label: 'Users',
    route: '/users',
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
  <main>
    <div class="flex">
      <!-- sidebar -->
      <div>
        <Menu ref="menu" pt:root:class="!rounded-none md:h-screen bg-surface-100 dark:bg-surface-700" :model="items" :popup="isMobile">
          <template #item="{ item, props }">
            <router-link v-if="item.route" v-slot="{ href, navigate }" :to="item.route" custom>
              <a v-ripple :href="href" v-bind="props.action" @click="navigate">
                <span :class="item.icon" />
                <span class="ml-2">{{ item.label }}</span>
              </a>
            </router-link>
            <a v-else v-ripple :href="item.url" :target="item.target" v-bind="props.action">
              <span :class="item.icon" />
              <span class="ml-2">{{ item.label }}</span>
            </a>
          </template>
        </Menu>
      </div>
      <div class="flex-1">
        <!-- header -->
        <div class="flex items-center justify-between bg-white px-3 py-2 shadow dark:bg-surface-900">
          <div>
            <Button v-if="isMobile" outline severity="secondary" icon="pi pi-bars" aria-isMobile="true" aria-controls="overlay_menu" @click="toggle" />
          </div>
          <Button :icon="`pi ${isDark ? 'pi-sun' : 'pi-moon'}`" text @click="toggleDark()" />
        </div>
        <div class="mb-4 border-b dark:border-surface-600" />
        <!-- content -->
        <div class="mx-4">
          <RouterView />
        </div>
      </div>
    </div>
  </main>
</template>
