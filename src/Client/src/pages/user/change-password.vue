<script setup lang="ts">
import { type ChangePasswordReq, authApi } from '~/api/auth'

const form = useForm<ChangePasswordReq>({} as ChangePasswordReq)
const toast = useToast()
async function onSubmit() {
  await form.submit(async (fields) => {
    await authApi.changePassword(fields)
    toast.add({ detail: 'Password changed successfully!', severity: 'success' })
    form.fields = { } as ChangePasswordReq
  })
}
</script>

<template>
  <div class="mx-auto my-sm max-w-xl card">
    <h1 class="mb-sm text-xl">
      Change Password
    </h1>
    <form @submit.prevent="onSubmit">
      <div class="mb-2 flex flex-col gap-2">
        <label for="oldPassword">Old Password</label>
        <Password id="oldPassword" v-model="form.fields.oldPassword" toggle-mask :feedback="false" placeholder="Enter your old password" type="password" />
        <small class="text-red-500">
          {{ form.errors.oldPassword?.[0] }}
        </small>
      </div>
      <div class="mb-2 flex flex-col gap-2">
        <label for="newPassword">New Password</label>
        <Password id="newPassword" v-model="form.fields.newPassword" toggle-mask :feedback="false" placeholder="Enter your new password" type="password" />
        <small class="text-red-500">
          {{ form.errors.newPassword?.[0] }}
        </small>
      </div>
      <div class="mb-2 flex flex-col gap-2">
        <label for="confirmPassword">Confirm Password</label>
        <Password id="confirmPassword" v-model="form.fields.confirmPassword" toggle-mask :feedback="false" placeholder="Confirm your new password" type="password" />
        <small class="text-red-500">
          {{ form.errors.confirmPassword?.[0] }}
        </small>
      </div>
      <div class="text-end">
        <Button label="Change Password" :loading="form.loading" type="submit" icon="pi pi-lock" />
      </div>
    </form>
  </div>
</template>
