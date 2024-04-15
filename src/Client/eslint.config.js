// @ts-check
import antfu from '@antfu/eslint-config'
import { FlatCompat } from '@eslint/eslintrc'

const compat = new FlatCompat()
export default antfu(
  {
    formatters: true,
    ignores: [
      'src/presets/*',
    ],
  },
  // Legacy config
  compat.config({
    extends: ['plugin:tailwindcss/recommended'],
  }),
)
