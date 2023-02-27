<template>
  <div id="app" style="height: 600px">
    <GcArViewer ref="control" v-bind:zoom="reportZoom" viewMode="paginated" v-bind:availableExports="['pdf', 'xlsx']"
      v-on:report-loaded="this.onReportLoaded" v-on:document-loaded="onDocumentLoaded"
      :report="{ Uri: 'InvoiceList.rdlx-json' }" />
  </div>
</template>

<script>
  import Vue from 'vue';
  import '@grapecity/activereports/styles/ar-js-viewer.css';
  import { Viewer } from '@grapecity/activereports-vue';
  import '@grapecity/activereports';

  export default Vue.extend({
    name: 'app',
    components: {
      GcArViewer: Viewer
    },
    data: function () {
      return {
        reportZoom: 'FitPage',
      }
    },
    mounted() {
      var htmlBtnIcon = '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" width="24" height="24"><path class="gc-icon-color--text" d="M19 26v2c0 1.1-.9 2-2 2H2c-1.1 0-2-.9-2-2V5c0-1.1.9-2 2-2h10v6c0 1.1.9 2 2 2h5v2H6c-1.7 0-3 1.3-3 3v7c0 1.7 1.3 3 3 3h13zM13 3v6c0 .6.5 1 1 1h5l-6-7zM6 14c-1.1 0-2 .9-2 2v7c0 1.1.9 2 2 2h23c1.1 0 2-.9 2-2v-7c0-1.1-.9-2-2-2H6zm23 8v1h-5v-7h1v6h4zm-15-5v6h1v-6h2v-1h-5v1h2zm-4 2v-3h1v7h-1v-3H7v3H6v-7h1v3h3zm10.5 0L19 16h-1v7h1v-5l1 2h1l1-2v5h1v-7h-1l-1.5 3z" fill-rule="evenodd" clip-rule="evenodd" /></svg>';
      this.getViewer().toolbar().addItem({
        key: '$html-export-btn',
        icon: { type: 'svg', content: htmlBtnIcon },
        title: "HTML Export",
        enabled: true,
        action: () => { this.getViewer().export('html', []).then((result) => result.download("Exported_HTML")) }
      });

    },
    methods: {
      onDocumentLoaded: function (a) {
        console.log("document loaded", a);
      },
      onReportLoaded: function (arg) {
        console.log("report loaded", arg);
      },
      getViewer() {
        return this.$refs.control;
      }
    }
  });
</script>