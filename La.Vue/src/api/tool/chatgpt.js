import axios from 'axios';

const API_KEY = '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';//替换成你申请的open AI key
const MODEL = 'text-davinci-002';//使用的语言模型

const api = axios.create({
  baseURL: 'https://baixiang.yunrobot.cn/v1/',
  headers: {
    'Authorization': `Bearer ${API_KEY}`,
    'Content-Type': 'application/json;charset=UTF-8',
  },
});

async function generateText(prompt) {
  const response = await api.post('/engines/text-davinci-002/completions', {
    prompt: prompt,//问的问题
    max_tokens: 1024,
    n: 1,
    stop: '\n',
  });
  return response.data.choices[0].text.trim();
}

export default {
  generateText,
};
