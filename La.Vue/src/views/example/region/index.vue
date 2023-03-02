<template>
  <div>
    <div style="color:Coral; font-weight:bolder">
      最新数据量 664483 （2022年10月31日）
    </div>
    <p style="color:rgb(57, 2, 145); font-weight:bolder">当前地址:
      {{form.province}}-{{form.city}}-{{form.region}}-{{form.street}}-{{form.village}}</p>
    <el-form>
      <el-form-item label="行政区划">
        <div>
          <el-select v-model="form.province" placeholder="省级" @change="changePr">
            <el-option v-for="item in provinceList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
          <el-select v-model="form.city" placeholder="市级" @change="changeCi">
            <el-option v-for="item in cityList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
          <el-select v-model="form.region" placeholder="区级" @change="changeRe">
            <el-option v-for="item in regionList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
          <el-select v-model="form.street" placeholder="乡镇" @change="changeSt">
            <el-option v-for="item in streetList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
          <el-select v-model="form.village" placeholder="村庄">
            <el-option v-for="item in villageList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
        </div>
      </el-form-item>
      <p style="color:rgb(110, 54, 2); font-weight:bolder">アドレス: {{form.japrovince}}-{{form.jacity}}</p>
      <el-form-item label="行政区划">
        <div>

          <el-select v-model="form.japrovince" placeholder="省级" @change="changejaPr">
            <el-option v-for="item in japrovinceList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
          <el-select v-model="form.jacity" placeholder="市级">
            <el-option v-for="item in jacityList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
        </div>
      </el-form-item>
      <p style="color:rgb(87, 1, 75); font-weight:bolder">當前地址:
        {{form.hkmotwprovince}}-{{form.hkmotwcity}}-{{form.hkmotwregion}}</p>
      <el-form-item label="行政区划">
        <div>
          <el-select v-model="form.hkmotwprovince" placeholder="省级" @change="changehkmotwPr">
            <el-option v-for="item in hkmotwprovinceList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
          <el-select v-model="form.hkmotwcity" placeholder="市级" @change="changehkmotwCi">
            <el-option v-for="item in hkmotwcityList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
          <el-select v-model="form.hkmotwregion" placeholder="区级">
            <el-option v-for="item in hkmotwregionList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
        </div>
      </el-form-item>
    </el-form>
    <div class="m-4">
      <p style="color:rgb(31, 24, 92); font-weight:bolder">Cascader 级联选择器</p>
      <el-cascader clearable v-model="selectedcate" :props="customProps" :options="pacsv" @change="handleChange"
        style="width:470px" />
    </div>
  </div>
</template>

<script setup>
  import pacasv from '@/views/example/region/pcasv-code.json'
  import japac from '@/views/example/region/japc-code.json'
  import hkmotwpac from '@/views/example/region/hkmotw-code.json'
  const state = reactive({
    form: { // 创建单位管理form
      province: '', // 行政区划--省
      city: '', // 行政区划--市
      region: '', // 行政区划--区
      street: '', // 行政区划--乡镇
      village: '', // 行政区划--村庄
      japrovince: '', // ja行政区划--省
      jacity: '', // ja行政区划--市
      hkmotwprovince: '', // hkmotw行政区划--省
      hkmotwcity: '', // hkmotw行政区划--市
      hkmotwregion: '', // hkmotw行政区划--区

    },
  })
  const pacsv = pacasv
  const customProps = {

    value: "code", // 自定义当前数组的键名 - value
    label: "name", // 自定义当前数组的键名 - label
    children: "children", // 自定义当前数组的键名 - children

  }

  const selectedcate = ref([])
  const { form } = toRefs(state)

  const provinceList = pacasv // 存放省数据集合
  const cityList = ref([]) // 存放市数据集合
  const regionList = ref([]) // 存放区数据集合
  const streetList = ref([]) //存放乡镇数据集合
  const villageList = ref([])//存放村庄数据集合
  const japrovinceList = japac // ja存放省数据集合
  const jacityList = ref([]) // ja存放市数据集合
  const hkmotwprovinceList = hkmotwpac // hkmotw行政区划--省集合
  const hkmotwcityList = ref([]) // hkmotw行政区划--市集合
  const hkmotwregionList = ref([]) // hkmotw行政区划--区集合

  function changePr() {
    for (var key of pacasv) {
      if (key.name == form.value.province) {
        cityList.value = key.children
        form.value.city = key.children[0].name //默认选择第一个显示

      }
    }
    changeCi()


  }
  function changeCi() {
    cityList.value.forEach((item, index) => {
      if (item.name == form.value.city) {
        regionList.value = item.children
        form.value.region = item.children[0].name //默认选择第一个显示

      }
    })
    changeRe()

  }
  function changeRe() {
    regionList.value.forEach((item, index) => {
      if (item.name == form.value.region) {
        streetList.value = item.children
        form.value.street = item.children[0].name  //默认选择第一个显示

      }
    })
    changeSt()
  }
  function changeSt() {
    streetList.value.forEach((item, index) => {
      if (item.name == form.value.street) {
        villageList.value = item.children
        form.value.village = item.children[0].name  //默认选择第一个显示

      }
    })

  }
  function changejaPr() {
    for (var key of japac) {
      if (key.name == form.value.japrovince) {
        jacityList.value = key.children
        form.value.jacity = key.children[0].name //默认选择第一个显示

      }
    }
  }
  function changehkmotwPr() {
    for (var key of hkmotwpac) {
      if (key.name == form.value.hkmotwprovince) {
        hkmotwcityList.value = key.children
        form.value.hkmotwcity = key.children[0].name //默认选择第一个显示
      }
    }
    changehkmotwCi()
  }
  function changehkmotwCi() {
    hkmotwcityList.value.forEach((item, index) => {
      if (item.name == form.value.hkmotwcity) {
        hkmotwregionList.value = item.children
        form.value.hkmotwregion = item.children[0].name //默认选择第一个显示

      }
    })

  }


</script>

<style>
</style>