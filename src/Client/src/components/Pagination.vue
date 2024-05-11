<script setup lang="ts">
const props = defineProps<{
  modelValue: number
  totalPages: number
}>()
const emits = defineEmits<{
  'update:modelValue': [number]
}>()
const { modelValue } = useVModels(props, emits)

function onPrev() {
  modelValue.value--
}
function onNext() {
  modelValue.value++
}
function onFirst() {
  modelValue.value = 1
}
function onLast() {
  modelValue.value = props.totalPages
}
</script>

<template>
  <div class="flex items-center gap-sm">
    <Button
      :disabled="modelValue <= 1"
      icon="pi pi-angle-double-left"
      text
      @click="onFirst"
    />
    <Button
      text
      :disabled="modelValue <= 1"
      icon="pi pi-chevron-left"
      @click="onPrev"
    />
    <div>
      <p class="text-xs">
        {{ modelValue }} / {{ totalPages }}
      </p>
    </div>
    <Button
      text
      :disabled="modelValue >= totalPages"
      icon="pi pi-chevron-right"
      @click="onNext"
    />
    <Button
      text
      :disabled="modelValue >= totalPages"
      icon="pi pi-angle-double-right"
      @click="onLast"
    />
  </div>
</template>
