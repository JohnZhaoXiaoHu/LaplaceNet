import autoImport from 'unplugin-auto-import/vite'

export default function createAutoImport() {
  return autoImport({
    include: [
      /\.[tj]sx?$/, // .ts, .tsx, .js, .jsx
      /\.vue$/,
      /\.vue\?vue/ // .vue
    ],
    imports: [
      'vue',
      'vue-router',
      'pinia'
    ],
    resolvers: [
      /* ... */
    ],
    dts: "src/auto-import.d.ts" // 生成 `auto-import.d.ts` 全局声明
  })
}