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
  ...compat.config({
    // https://github.com/francoismassart/eslint-plugin-tailwindcss
    extends: ['plugin:tailwindcss/recommended'],
  }),
)
