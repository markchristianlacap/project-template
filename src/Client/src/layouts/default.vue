<script setup lang="ts">
import type { MenuItem } from 'primevue/menuitem'

const menu = ref()
const userStore = useUserStore()
const toast = useToast()
const router = useRouter()
const confirm = useConfirm()
const userMenus: MenuItem[] = [
  {
    label: 'User Menu',
    items: [
      {
        label: 'Change Password',
        icon: 'pi pi-key',
        command: () => {
          router.push('/user/change-password')
        },
      },
      {
        label: 'Update Profile',
        icon: 'pi pi-user-edit',
      },
    ],
  },
]
const links = ref<MenuItem[]>([
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

])
function logout(event: MouseEvent) {
  confirm.require({
    target: event.currentTarget as HTMLElement,
    message: 'Are you sure you want to logout?',
    acceptLabel: 'Yes',
    rejectLabel: 'No',
    acceptProps: { severity: 'danger' },
    accept: async () => {
      await userStore.logout()
      toast.add({ severity: 'info', detail: 'Logout successfully' })
      router.push('/')
    },
  })
}
function toggle(event: MouseEvent) {
  menu.value.toggle(event)
}
</script>

<template>
  <main>
    <Menubar :model="links" pt:root:class="!rounded-none !bg-surface-100 dark:!bg-surface-900">
      <template #start>
        <div class="flex items-center justify-center gap-2">
          <p class="jersey-25-regular border-r pr-2 text-2xl font-bold">
            ADMIN
          </p>
          <p class="text-xs">
            Panel
          </p>
        </div>
      </template>
      <template #item="{ item, props, hasSubmenu }">
        <router-link v-if="item.route" v-slot="{ href, navigate }" :to="item.route" custom>
          <a v-ripple :href="href" v-bind="props.action" @click="navigate">
            <span :class="item.icon" />
            <span class="ml-2">{{ item.label }}</span>
          </a>
        </router-link>
        <a v-else v-ripple :href="item.url" :target="item.target" v-bind="props.action">
          <span :class="item.icon" />
          <span class="ml-2">{{ item.label }}</span>
          <span v-if="hasSubmenu" class="pi pi-fw pi-angle-down ml-2" />
        </a>
      </template>
      <template #end>
        <Button type="button" icon="pi-user pi" text aria-haspopup="true" aria-controls="user_item_menu" @click="toggle" />
        <Menu ref="menu" :model="userMenus" :popup="true" />
        <Button v-tooltip="'Toggle dark mode'" :icon="`pi ${isDark ? 'pi-sun' : 'pi-moon'}`" text @click="toggleDark()" />
        <Button v-tooltip="`Logout your account`" icon="pi pi-sign-out" text @click="logout" />
      </template>
    </Menubar>
    <RouterView />
  </main>
</template>
