<template>
  <div class="chart-warp-top">
    <ChartHead />
  </div>
  <div>
    <div class="card mb10">
      <h4 class="title">{{ $t('layout.ProjectInformation') }}</h4>
    </div>
    <div class="card mb10">
      <h4 class="title"> {{ $t('layout.projectInfo') }}</h4>
      <el-descriptions :column="2" border>
        <el-descriptions-item :label=" $t('layout.currentVersion')" label-align="left">
          <el-tag>{{ version }}</el-tag>
        </el-descriptions-item>
        <el-descriptions-item :label=" $t('layout.lastBulid')" label-align="left">
          <el-tag>{{ lastBuildTime }}</el-tag>
        </el-descriptions-item>
        <el-descriptions-item label="Gitee" label-align="left">
          <el-link type="primary" href="https://github.com/Lean365/LaplaceNet" target="_blank"> Gitee </el-link>
        </el-descriptions-item>
        <el-descriptions-item label="Github" label-align="left">
          <el-link type="primary" href="https://github.com/Lean365/LaplaceNet" target="_blank"> Github </el-link>
        </el-descriptions-item>
        <el-descriptions-item :label=" $t('layout.helpguide')" label-align="left">
          <el-link type="primary" href="https://laplacenet.github.io/" target="_blank"> {{$t('layout.helpguide')}}
          </el-link>
        </el-descriptions-item>
        <el-descriptions-item :label=" $t('btn.preview')" label-align="left">
          <el-link type="primary" href="https://laplacenet.github.io/" target="_blank"> {{$t('btn.preview')}} </el-link>
        </el-descriptions-item>
      </el-descriptions>
    </div>
    <div class="card mb10">
      <h4 class="title">{{ $t('layout.dependencies') }}</h4>
      <el-descriptions :column="3" border>
        <el-descriptions-item v-for="(value, key) in dependencies" :key="key" width="400px" :label="key">
          <el-tag type="info">
            {{ value }}
          </el-tag>
        </el-descriptions-item>
      </el-descriptions>
    </div>
    <div class="card">
      <h4 class="title">{{ $t('layout.devDependencies') }}</h4>
      <el-descriptions :column="3" border>
        <el-descriptions-item v-for="(value, key) in devDependencies" :key="key" width="400px" :label="key">
          <el-tag type="info">
            {{ value }}
          </el-tag>
        </el-descriptions-item>
      </el-descriptions>
    </div>
  </div>
</template>

<script setup name="about">
  // 引入组件
  const ChartHead = defineAsyncComponent(() => import('@/utils/ontime.vue'));
  const { pkg, lastBuildTime } = __APP_INFO__;
  const { dependencies, devDependencies, version } = pkg;

</script>

<style lang="scss" scoped>
  .card {
    .title {
      margin: 0 0 15px;
      font-size: 17px;
      font-weight: bold;
      color: var(--el-text-color-primary);
    }

    .text {
      font-size: 15px;
      line-height: 25px;
      color: var(--el-text-color-regular);

      .el-link {
        font-size: 15px;
      }
    }
  }
</style>