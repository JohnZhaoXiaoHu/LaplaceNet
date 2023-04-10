
export default {
  computed: {
    currentUserId() {
      return this.$store.state.user.user.id;
    },
  },
  data() {
    return {
      moduleName: '',
      tableData: [],
      page: {
        total: 100,
        maxResultCount: 50,
        currentPage: 1,
        conditions: [],
        sorting: "creationtime desc",
      },
      loading: {
        getPageList: false
      }
    };
  },
  watch:{
    currentUserId(){
      if(this.getPageList)
        this.getPageList();
    }
  },
  mounted() {
    this.getPageList();
  },
  methods: {
    dateFormat(row, column) {
      let data = row[column.property];
      if (data === null) {
        return "";
      }
      let dt = new Date(data);
      // console.log("dt"+dt);
      return (
        dt.getFullYear() +
        "-" +
        (dt.getMonth() + 1) +
        "-" +
        dt.getDate() +
        " " +
        dt.getHours() +
        ":" +
        dt.getMinutes() +
        ":" +
        dt.getSeconds()
      );
    },
    paginationChange(size, current) {
      if (size) this.page.maxResultCount = size;
      if (current) this.page.currentPage = current;
      this.getPageList();
    },
    create() {
      this.$refs.createForm.show()
    },
    edit(id) {
      this.$refs.editForm.show(id)
    },
    getPageList() {
      this.loading.getPageList = true
      this.page.skipCount =
        (this.page.currentPage - 1) * this.page.maxResultCount;
      this.$store.dispatch(this.moduleName + "/getPageList", this.page).then((res) => {
        this.tableData = res.items;
        this.page.total = res.total;
        this.loading.getPageList = false
      });
    },
    remove(id) {
      this.$confirm("确认删除该记录？, 是否继续?", "提示", {
          confirmButtonText: "确定",
          cancelButtonText: "取消",
          type: "warning",
        })
        .then(() => {
          this.$store.dispatch(this.moduleName + "/delete", {
            id: id
          }).then((res) => {
            this.$message({
              type: "success",
              message: "删除成功!",
            });
            this.getPageList();
          });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消删除",
          });
        });
    },
  },
};
