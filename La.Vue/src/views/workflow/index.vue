<template>
  <div class="app-container">
    <div class="bpmn-main-box">
      <div ref="bpmn" id="bpmn-container" class="bpmn-container"></div>
      <div ref="bpmnPanel" id="js-properties-panel"></div>
    </div>
    <ul class="buttons">
      <input ref="fileElement" type="file" style="display: none" @change="fileChange" />
      <el-button-group class="item download">
        <el-button type="primary" @click="upload()">
          <a title="上传文件"><el-icon>
              <FolderAdd />
            </el-icon></a>
        </el-button>
        <el-button type="primary" @click="newCreateDoc()">
          <a title="新建"><el-icon>
              <DocumentAdd />
            </el-icon></a>
        </el-button>
      </el-button-group>
      <el-button-group class="item download">
        <el-button @click="downloadLinkClick()" type="primary">
          <a ref="downloadLinkEl" id="js-download-diagram" title="xml下载"><el-icon>
              <Download />
            </el-icon></a>
        </el-button>
        <el-button @click="downloadSvg" type="primary">
          <a ref="downloadSvgEl" id="js-download-svg" title="svg下载"><el-icon>
              <PictureFilled />
            </el-icon></a>
        </el-button>
      </el-button-group>
      <el-button-group class="item download">
        <el-button type="primary" @click="perviewXML">
          <a title="xml预览"><el-icon>
              <Document />
            </el-icon></a>
        </el-button>
        <el-button type="primary" @click="perviewSVG">
          <a title="svg预览"><el-icon>
              <View />
            </el-icon></a>
        </el-button>
      </el-button-group>
    </ul>
    <el-dialog title="XML预览" width="80%" v-model="perviewXMLShow">
      <div style="max-height: 65vh;overflow: auto;">
        <highlightjs language='html' :code="perviewXMLStr" />
      </div>
    </el-dialog>
    <el-dialog title="SVG预览" width="80%" v-model="perviewSVGShow">
      <div style="text-align: center;" v-html="perviewSVGData" />
    </el-dialog>
  </div>
</template>
<script setup lang="ts">
  import { onMounted, Ref, ref } from 'vue'
  import { ElButton, ElDialog, ElButtonGroup, ElIcon } from 'element-plus'
  import { DocumentAdd, FolderAdd, Document, View, PictureFilled, Download } from '@element-plus/icons-vue'
  import 'element-plus/theme-chalk/index.css';
  // 样式
  import 'bpmn-js/dist/assets/diagram-js.css'
  import 'bpmn-js/dist/assets/bpmn-font/css/bpmn.css'
  import 'bpmn-js/dist/assets/bpmn-js.css'
  import 'bpmn-js/dist/assets/bpmn-font/css/bpmn-codes.css'
  import 'bpmn-js/dist/assets/bpmn-font/css/bpmn-embedded.css'
  import 'bpmn-js-properties-panel/dist/assets/element-templates.css';
  import 'bpmn-js-properties-panel/dist/assets/properties-panel.css';
  // bpmn构建器
  import BpmnModeler from 'bpmn-js/lib/Modeler.js' // 引入 bpmn-js
  // 初始化xml
  import diagramXML from '@/assets/bpmnXML'
  // 汉化
  import zh from '@/assets/zh'
  // 汉化文件夹
  //import customTranslate from "@/assets/customTranalate/customTranslate.js";
  import customTranslate from '@/assets/customTranslate/customTranslate'
  // 构建模块
  import {
    BpmnPropertiesPanelModule,
    BpmnPropertiesProviderModule,
    CamundaPlatformPropertiesProviderModule,
    CloudElementTemplatesPropertiesProviderModule
  } from 'bpmn-js-properties-panel'
  import camundaModdleDescriptor from 'camunda-bpmn-moddle/resources/camunda.json'

  const bpmn = ref(null)
  const bpmnPanel = ref(null)
  const fileElement = ref(null)
  const downloadLinkEl = ref(null)
  const downloadSvgEl = ref(null)
  let bpmnModeler = ref(null)
  let perviewXMLShow = ref(false)
  let perviewSVGShow = ref(false)
  let perviewXMLStr = ref('')
  let perviewSVGData = ref('')

  onMounted(() => {
    bpmnModeler.value = new BpmnModeler({
      container: bpmn.value,
      propertiesPanel: {
        parent: bpmnPanel.value
      },
      additionalModules: [
        BpmnPropertiesPanelModule,
        BpmnPropertiesProviderModule,
        CamundaPlatformPropertiesProviderModule,
        CloudElementTemplatesPropertiesProviderModule,
        {
          translate: ['value', customTranslate]
        }
      ],
      moddleExtensions: {
        camunda: camundaModdleDescriptor
      }
    })
    createNewDiagram()
  })

  // 文件上传
  function fileChange() {
    if (fileElement.value && fileElement.value.files) {
      const file = fileElement.value.files[0]
      const fileReader = new FileReader();
      fileElement.value.value = ''
      fileReader.onload = (e) => {
        bpmnModeler.value.importXML(e.target.result)
      }
      fileReader.readAsText(file);
    }
  }
  // 点击文件上传
  function upload() {
    fileElement.value?.click()
  }
  // 新建
  function newCreateDoc() {
    bpmnModeler.value.importXML(diagramXML)
  }
  // 下载XML
  async function downloadLinkClick() {
    try {
      const { xml } = await bpmnModeler.value.saveXML({ format: true });
      setEncoded(downloadLinkEl, 'diagram.bpmn', xml);
    } catch (error) {
      console.error('下载失败');
    }
  }
  // 下载SVG
  async function downloadSvg() {
    try {
      const { svg } = await bpmnModeler.value.saveSVG();
      setEncoded(downloadSvgEl, 'diagram.svg', svg);
    } catch (error) {
      console.error('下载失败，请重试')
    }
  }
  // XML预览
  async function perviewXML() {
    try {
      const { xml } = await bpmnModeler.value.saveXML({ format: true });
      perviewXMLStr.value = xml
      perviewXMLShow.value = true
    } catch (error) {
      console.error('预览失败，请重试')
    }
  }
  // SVG预览
  async function perviewSVG() {
    try {
      const { svg } = await bpmnModeler.value.saveSVG();
      perviewSVGData.value = svg
      perviewSVGShow.value = true
    } catch (error) {
      console.error('预览失败，请重试')
    }
  }
  // 汉化
  // function customTranslate(template, replacements) {
  //   replacements = replacements || {};
  //   template = (zh)[template] || template;
  //   return template.replace(/{([^}]+)}/g, function (_, key) {
  //     return replacements[key] || '{' + key + '}';
  //   });
  // }
  // 设置数据
  function setEncoded(link, name, data) {
    const encodedData = encodeURIComponent(data);
    if (link.value && data) {
      link.value.className += ('active')
      link.value.setAttribute('href', 'data:application/bpmn20-xml;charset=UTF-8,' + encodedData)
      link.value.setAttribute('download', name)
    } else {
      link.value?.className.replace('active', '')
    }
  }
  // 创建BPMN区域
  function createNewDiagram() {
    openDiagram(diagramXML);
  }
  async function openDiagram(xml) {
    bpmnModeler.value.importXML(xml);
  }
</script>



<style lang="scss" scoped>
  .app-container {
    position: relative;
    height: 100vh;
    width: 100%;
  }

  .buttons {
    position: absolute;
    bottom: 30px;
    display: flex;
    left: 50px;
    padding: 0;
    margin: 0;
    list-style: none;

    .item {
      margin-right: 10px;
    }

    .download button {
      padding: 0;

      a {
        padding: 8px 15px;
      }
    }
  }

  .bpmn-main-box {
    width: 100%;
    height: 100%;
    display: flex;
  }

  .bpmn-container {
    width: 100%;
    height: 100%;
    background: url('data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iNDAiIGhlaWdodD0iNDAiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PGRlZnM+PHBhdHRlcm4gaWQ9ImEiIHdpZHRoPSI0MCIgaGVpZ2h0PSI0MCIgcGF0dGVyblVuaXRzPSJ1c2VyU3BhY2VPblVzZSI+PHBhdGggZD0iTTAgMTBoNDBNMTAgMHY0ME0wIDIwaDQwTTIwIDB2NDBNMCAzMGg0ME0zMCAwdjQwIiBmaWxsPSJub25lIiBzdHJva2U9IiNlMGUwZTAiIG9wYWNpdHk9Ii4yIi8+PHBhdGggZD0iTTQwIDBIMHY0MCIgZmlsbD0ibm9uZSIgc3Ryb2tlPSIjZTBlMGUwIi8+PC9wYXR0ZXJuPjwvZGVmcz48cmVjdCB3aWR0aD0iMTAwJSIgaGVpZ2h0PSIxMDAlIiBmaWxsPSJ1cmwoI2EpIi8+PC9zdmc+') repeat !important;
  }

  #js-properties-panel {
    border: 1px solid rgba(0, 0, 0, 0.1);
    width: 250px;
  }

  .code-block {
    white-space: pre;
    max-height: 600px;
    overflow-y: auto;
    font-size: medium;
    color: #a9b7c6;
    background: #282b2e;
    padding: 16px;
  }

  a {
    text-decoration: none;
    color: #fff;
  }
</style>