import autoImport from 'unplugin-auto-import/vite'

export default function createAutoImport() {
  return autoImport({

    // targets to transform

    // global imports to register
    imports: [
      // presets
      'vue',
      'vue-router',
      'pinia',
      // custom

      // example type import

    ],
    dts: "src/auto-import.d.ts" // 生成 `auto-import.d.ts` 全局声明
  })
}