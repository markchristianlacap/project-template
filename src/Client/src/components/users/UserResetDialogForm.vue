<script setup lang="ts">
import { type UserResetPasswordReq, usersApi } from '~/api/users'
import type { Errors } from '~/types/errors'

const props = defineProps<{
  id: string
  dialog: boolean
}>()
const emits = defineEmits<{
  'success': []
  'update:dialog': [boolean]
}>()
const form = ref<UserResetPasswordReq>({
  confirmPassword: '',
  newPassword: '',
})
const { dialog } = useVModels(props, emits)
const loading = ref(false)
const errors = ref<Errors<UserResetPasswordReq>>({})

async function resetPassword() {
  try {
    loading.value = true
    await usersApi.resetPassword(props.id, form.value)
  }
  catch (e) {
    if (isAxiosError(e))
      errors.value = e?.response?.data?.errors || {}
  }
  loading.value = false
  emits('success')
}

watch(dialog, (v) => {
  if (!v) {
    form.value = {
      confirmPassword: '',
      newPassword: '',
    }
    errors.value = {}
  }
})
</script>

<template>
  <Dialog v-model:visible="dialog" class="w-full" modal header="Reset Password">
    <form @submit.prevent="resetPassword">
      <div class="flex flex-col gap-2">
        <label for="newPassword">New Password</label>
        <Password
          v-model="form.newPassword"
          toggle-mask
        />
        <small v-if="errors.newPassword" class="text-red">
          {{ errors.newPassword[0] }}
        </small>
      </div>
      <div class="mt-sm flex flex-col gap-2">
        <label for="confirmPassword">Confirm New Password</label>
        <Password
          v-model="form.confirmPassword"
          toggle-mask
        />
        <small v-if="errors.confirmPassword" class="text-red">
          {{ errors.confirmPassword[0] }}
        </small>
      </div>
      <div class="mt-xl flex justify-end gap-sm">
        <Button :disabled="loading" severity="warning" text @click="dialog = false">
          Cancel
        </Button>
        <Button type="submit" :loading="loading" label="Reset" />
      </div>
    </form>
  </Dialog>
</template>
