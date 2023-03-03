<template>
  <div class="page-register">
    <article class="header">
      <header>
        <el-avatar icon="el-icon-user-solid" shape="circle"></el-avatar>
        <span class="login">
          <em class="bold">已有账号？</em>
          <a href="/login">
            <el-button type="primary" size="small">登录</el-button>
          </a>
        </span>
      </header>
    </article>
    <el-steps :active="active" finish-status="success">
      <el-step title="阅读注册协议"></el-step>
      <el-step title="填写登录信息"></el-step>
      <el-step title="填写公司信息"></el-step>
    </el-steps>
    <section>
      <el-form ref="ruleForm" :model="ruleForm" :rules="rules" label-width="100px" autocomplete="off" size="medium">
        <div v-if="active == 0">
          <el-form-item prop="textarea">
            <el-input type="textarea" :autosize="{ minRows: 2, maxRows: 10 }" :readonly="true"
              v-html="ruleForm.textarea">
            </el-input>
          </el-form-item>
          <el-form-item prop="agreed">
            <el-checkbox v-model="ruleForm.agreed">同意注册协议</el-checkbox>
          </el-form-item>
        </div>
        <div v-if="active == 1" style="padding-top:10px">

          <el-form-item label="用户名" prop="name">
            <el-col :span="10">
              <el-input v-model="ruleForm.name" />
            </el-col>
          </el-form-item>

          <el-form-item label="邮箱" prop="email">
            <el-col :span="10">
              <el-input v-model="ruleForm.email" />
            </el-col>
            <el-button :loading="codeLoading" :disabled="isDisable" size="small" round
              @click="sendMsg">发送验证码</el-button>

            <span class="status">{{ statusMsg }}</span>
          </el-form-item>
          <el-form-item label="验证码" prop="code">
            <el-col :span="10">
              <el-input v-model="ruleForm.code" maxlength="6" />
            </el-col>
          </el-form-item>
          <el-form-item label="手机号" prop="phone">
            <el-col :span="10">
              <el-input v-model="ruleForm.phone" maxlength="11" />
            </el-col>
          </el-form-item>
          <el-form-item label="密码" prop="pwd">
            <el-col :span="10">
              <el-input v-model="ruleForm.pwd" type="password" />
            </el-col>
          </el-form-item>
          <el-form-item label="确认密码" prop="cpwd">
            <el-col :span="10">
              <el-input v-model="ruleForm.cpwd" type="password" />
            </el-col>
          </el-form-item>
        </div>
        <div v-if="active == 2">
          <el-form-item label="公司名称" prop="companyFullName" size="mini">
            <el-input v-model="ruleForm.companyFullName" />
          </el-form-item>
          <el-form-item label="公司地址" prop="companyAddress" size="mini">
            <el-input v-model="ruleForm.companyAddress" />
          </el-form-item>
          <el-form-item label="供货范围" prop="supplierGoods" size="mini">
            <el-input v-model="ruleForm.supplierGoods" type="textarea" />
          </el-form-item>
          <el-row>
            <el-col span="12">
              <el-form-item label="法人" prop="person" size="mini">

                <el-input v-model="ruleForm.person" />

              </el-form-item>
            </el-col>
            <el-col span="12">
              <el-form-item label="注册资金" prop="fund" size="mini">

                <el-input v-model="ruleForm.fund" />

              </el-form-item>
            </el-col>
          </el-row>
        </div>
      </el-form>
    </section>

    <div class="footer">
      <el-button v-if="active > 0" type="info" icon="el-icon-arrow-left" @click="prev">上一步
      </el-button>
      <el-button v-if="active < step - 1" type="primary" icon="el-icon-arrow-right" @click="next">下一步</el-button>
      <el-button v-if="active == step - 1" type="primary" @click="register">注册</el-button>
      <div class="error">{{ error }}</div>
    </div>
  </div>
</template>

<script>
  import { getEmailCode, register } from '@/api/login'
  import { encrypt } from '@/utils/rsaEncrypt'
  export default {
    data() {
      return {
        step: 3,
        active: 0,
        statusMsg: '',
        error: '',
        isDisable: false,
        codeLoading: false,
        ruleForm: {
          textarea: '<h1 style=" line-height:40px; font-size:24px; text-align:center;">“SRM采购平台”服务条例</h1>' +
            ' 6.1 如因系统维护或升级的需要而需暂停平台服务，“电子化采购平台”将尽可能事先进行通告 <br />' +
            '6.2 如发生下列任何一种情形，“电子化采购平台”有权随时中断或终止向用户提供本协议项下的平台服务而无需通知用户： <br />' +
            '(a) 用户提供的资料不真实； <br /> (b) 用户违反本条例中规定的规则； <br />（c）其他严重违反“电子化采购平台”管理规定的行为。 <br />' +
            '6.3 除前款所述情形外，“电子化采购平台”保留随时修改其服务体系和价格而不需通知用户的权利，对于所有服务的中断或终止而造成的任何损失，“高子化采购平台”无需对用户或任何第三方承担任何责任。' +
            ' 6.1 如因系统维护或升级的需要而需暂停平台服务，“电子化采购平台”将尽可能事先进行通告 <br />' +
            '6.2 如发生下列任何一种情形，“电子化采购平台”有权随时中断或终止向用户提供本协议项下的平台服务而无需通知用户： <br />' +
            '(a) 用户提供的资料不真实； <br /> (b) 用户违反本条例中规定的规则； <br />（c）其他严重违反“电子化采购平台”管理规定的行为。 <br />',
          agreed: false,
          name: '',
          code: '',
          pwd: '',
          cpwd: '',
          email: '',
          companyFullName: ''
        },
        rules: {
          agreed: [{
            validator: (rule, value, callback) => {
              if (value !== true) {
                callback(new Error('请确认同意注册协议'))
              } else {
                callback()
              }
            },
            trigger: 'blur'
          }],
          name: [{
            required: true,
            type: 'string',
            message: '请输入用户名',
            trigger: 'blur'
          }],
          code: [{
            required: true,
            type: 'string',
            message: '请输入验证码',
            trigger: 'blur'
          }],
          email: [{
            required: true,
            type: 'email',
            message: '请输入邮箱',
            trigger: 'blur'
          }],
          phone: [
            { required: true, message: '请输入手机号码', trigger: 'blur' },
            {
              validator: function (rule, value, callback) {
                if (/^1[34578]\d{9}$/.test(value) === false) {
                  callback(new Error('请输入正确的手机号'))
                } else {
                  callback()
                }
              }, trigger: 'blur'
            }
          ],
          pwd: [{
            required: true,
            message: '创建密码',
            trigger: 'blur'
          }, { pattern: /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,20}$/, message: '密码必须同时包含数字与字母,且长度为 8-20位' }],
          cpwd: [{
            required: true,
            message: '确认密码',
            trigger: 'blur'
          }, {
            validator: (rule, value, callback) => {
              if (value === '') {
                callback(new Error('请再次输入密码'))
              } else if (value !== this.ruleForm.pwd) {
                callback(new Error('两次输入密码不一致'))
              } else {
                callback()
              }
            },
            trigger: 'blur'
          }],
          companyFullName: [{
            required: true,
            type: 'string',
            message: '请输入公司名称',
            trigger: 'blur'
          }]
        }
      }
    },
    layout: 'blank',
    methods: {
      sendMsg: function () {
        const self = this
        let namePass
        let emailPass
        let timerid
        console.log(timerid)
        if (timerid) {
          return false
        }
        this.$refs['ruleForm'].validateField('name', (valid) => {
          namePass = valid
        })
        self.statusMsg = ''
        if (namePass) {
          return false
        }
        this.$refs['ruleForm'].validateField('email', (valid) => {
          emailPass = valid
        })
        // 向后台API验证码发送
        if (!namePass && !emailPass) {
          self.codeLoading = true
          self.statusMsg = '验证码发送中...'
          getEmailCode(self.ruleForm.email).then(res => {
            this.$message({
              showClose: true,
              message: '发送成功，验证码有效期5分钟',
              type: 'success'
            })
            let count = 60
            self.ruleForm.code = ''
            self.codeLoading = false
            self.isDisable = true
            self.statusMsg = `验证码已发送,${count--}秒后重新发送`
            timerid = window.setInterval(function () {
              self.statusMsg = `验证码已发送,${count--}秒后重新发送`
              if (count <= 0) {
                console.log('clear' + timerid)
                window.clearInterval(timerid)
                self.isDisable = false
                self.statusMsg = ''
              }
            }, 1000)
          }).catch(err => {
            this.isDisable = false
            this.statusMsg = ''
            this.codeLoading = false
            console.log(err.response.data.message)
          })
        }
      },

      next: function () {
        if (this.active === 0) {
          this.$refs['ruleForm'].validateField('agreed', (valid) => {
            if (valid === '') {
              this.active++
            }
          })
        } else if (this.active === 1) {
          this.active++
        }
      },
      prev: function () {
        this.$refs['ruleForm'].clearValidate()
        if (--this.active < 0) this.active = 0
      },

      // 用户注册
      register: function () {
        this.$refs['ruleForm'].validate((valid) => {
          if (valid) {
            const user = {
              username: this.ruleForm.email,
              nickName: this.ruleForm.name,
              code: this.ruleForm.code,
              password: encrypt(this.ruleForm.pwd),
              email: this.ruleForm.email,
              phone: this.ruleForm.phone,
              enabled: true
            }
            register(this.ruleForm.code, user).then(res => {
              this.$message({
                showClose: true,
                message: '注册成功',
                type: 'success'
              })
              setTimeout(() => {
                this.$router.push('/')
              }, 2000)
            }).catch(err => {
              console.log(err.response.data.message)
            })
          }
        })
      }
    }
  }
</script>

<style rel="stylesheet/scss" lang="scss">
  .page-register {
    .header {
      //border-bottom: 2px solid rgb(235, 232, 232);
      min-width: 980px;
      color: #666;

      header {
        margin: 0 auto;
        padding: 10px 0;
        width: 980px;

        .login {
          float: right;
        }

        .bold {
          font-style: normal;
        }
      }
    }

    .register {
      color: #1890ff;
    }

    a {
      color: #1890ff;
      text-decoration: none;
      background-color: transparent;
      outline: none;
      cursor: pointer;
      transition: color 0.3s;
    }

    >section {
      margin: 0 auto 30px;
      padding-top: 30px;
      width: 980px;
      min-height: 300px;
      padding-right: 100px;
      box-sizing: border-box;

      .status {
        font-size: 12px;
        margin-left: 20px;
        color: #e6a23c;
      }

      .error {
        color: red;
      }
    }

    .footer {
      text-align: center;
      padding-right: 100px;
    }
  }
</style>