// 获取当前时间并格式化2022-12-12 10:00:000
export function getCurrentTime () {
  var date = new Date()
  var month = date.getMonth() + 1
  var day = date.getDate()
  if (month <= 9) {
    month = '0' + month
  }
  if (day <= 9) {
    day = '0' + day
  }
  return date.getFullYear() + '-' + month + '-' + day + '  ' + date.getHours() + ':' + date.getMinutes() + ':' + date.getSeconds()
}

// 获取当前时间并格式化20221212  
//padStart()用于头部补全，padEnd()用于尾部补全
export function getCurrentDate () {
  var date = new Date()
  var month = (date.getMonth() + 1).toString().padStart(2, 0)
  var day = date.getDate().toString().padStart(2, 0)
  return date.getFullYear().toString() + month.toString() + day.toString()
}


// 时间格式化
export function formatTime (v) {
  var date = new Date(v)
  var month = date.getMonth() + 1
  var day = date.getDate()
  if (month <= 9) {
    month = '0' + month
  }
  if (day <= 9) {
    day = '0' + day
  }
  return date.getFullYear() + '-' + month + '-' + day + '  ' + date.getHours() + ':' + date.getMinutes() + ':' + date.getSeconds()
}

// 日期格式化
export function formatDate (v) {
  var date = new Date(v)
  var month = date.getMonth() + 1
  var day = date.getDate()
  if (month <= 9) {
    month = '0' + month
  }
  if (day <= 9) {
    day = '0' + day
  }
  return date.getFullYear() + '-' + month + '-' + day
}

// 获取前、后n天 
export function getRangeDate (num, time) {
  let n = num;
  let d = '';
  if (time) {
    d = new Date(time);
  } else {
    d = new Date();
  }
  let year = d.getFullYear();
  let mon = d.getMonth() + 1;
  let day = d.getDate();
  if (day <= n) {
    if (mon > 1) {
      mon = mon - 1;
    } else {
      year = year - 1;
      mon = 12;
    }
  }
  d.setDate(d.getDate() - n);
  year = d.getFullYear();
  mon = d.getMonth() + 1;
  day = d.getDate();
  let s = year + "-" + (mon < 10 ? ('0' + mon) : mon) + "-" + (day < 10 ? ('0' + day) : day);
  return s;
}

//获取某个月的起始、终止日期
export function getMonthDate (y, m) {
  let start = new Date(y, m - 1, 1)
  let year = start.getFullYear();
  let mon = start.getMonth() + 1;
  let day = start.getDate();
  let startDate = year + "-" + (mon < 10 ? ('0' + mon) : mon) + "-" + (day < 10 ? ('0' + day) : day)

  let end = new Date((new Date(y, m, 0).getTime() + 24 * 60 * 60 * 1000) - 1)
  let year1 = end.getFullYear();
  let mon1 = end.getMonth() + 1;
  let day1 = end.getDate();
  let endDate = year1 + "-" + (mon1 < 10 ? ('0' + mon1) : mon1) + "-" + (day1 < 10 ? ('0' + day1) : day1)

  return startDate + ' —— ' + endDate
}

/*
  当前日期是年的第几周
  date1是当前日期
  date2是当年第一天
  d是当前日期是今年第多少天
  用d + 当前年的第一天的周差距的和在除以7就是本年第几周
*/
export function getYearWeek (a, b, c) {
  var date1 = new Date(a, parseInt(b) - 1, c),
    date2 = new Date(a, 0, 1),
    d = Math.round((date1.valueOf() - date2.valueOf()) / 86400000)

  return Math.ceil((d + ((date2.getDay() + 1) - 1)) / 7)
}

// 计算某年某周的日期范围 
export function weekGetDate (year, weeks) {
  var date = new Date(year, "0", "1")
  var time = date.getTime() // 获取当前星期几,0:星期一     
  var _week = date.getDay()    //当这一年的1月1日为周日时则本年有54周,否则没有54周,没有则去除第54周的提示    
  if (_week != 0) {//一年53周情况
    if (weeks == 54) {
      return '-1' //今年没有54周
    }
    var cnt = 0// 获取距离周末的天数    
    if (_week == 0) {
      cnt = 7
    } else if (_week == 1) {
      cnt = 6
    } else if (_week == 2) {
      cnt = 5
    } else if (_week == 3) {
      cnt = 4
    } else if (_week == 4) {
      cnt = 3
    } else if (_week == 5) {
      cnt = 2
    } else if (_week == 6) {
      cnt = 1
    }
    cnt += 1//加1表示以星期一为一周的第一天    // 将这个长整形时间加上第N周的时间偏移    
    time += cnt * 24 * 3600000 //第2周开始时间 
    var nextYear = new Date(parseInt(year, 10) + 1, "0", "1")
    var nextWeek = nextYear.getDay()
    var lastcnt = 0//获取最后一周开始时间到周末的天数    
    if (nextWeek == 0) {
      lastcnt = 6
    } else if (nextWeek == 1) {
      lastcnt = 0
    } else if (nextWeek == 2) {
      lastcnt = 1
    } else if (nextWeek == 3) {
      lastcnt = 2
    } else if (nextWeek == 4) {
      lastcnt = 3
    } else if (nextWeek == 5) {
      lastcnt = 4
    } else if (nextWeek == 6) {
      lastcnt = 5
    }
    if (weeks == 1) {//第1周特殊处理    // 为日期对象 date 重新设置成时间 time
      // var start = date.Format("yyyy-MM-dd");
      var start = date.toLocaleDateString().split('/').join('-')
      date.setTime(time - 24 * 3600000)
      var end = date.toLocaleDateString().split('/').join('-')
      return start + "-----" + end
    } else if (weeks == 53) {//第53周特殊处理    
      var start = time + (weeks - 2) * 7 * 24 * 3600000 //第53周开始时间    
      var end = time + (weeks - 2) * 7 * 24 * 3600000 + lastcnt * 24 * 3600000 - 24 * 3600000 //第53周结束时间
      date.setTime(start)
      // var _start = date.Format("yyyy-MM-dd");
      var _start = date.toLocaleDateString().split('/').join('-')
      date.setTime(end)
      // var _end = date.Format("yyyy-MM-dd");
      var _end = date.toLocaleDateString().split('/').join('-')
      return _start + "---" + _end
    } else {
      var start = time + (weeks - 2) * 7 * 24 * 3600000 //第n周开始时间    
      var end = time + (weeks - 1) * 7 * 24 * 3600000 - 24 * 3600000 //第n周结束时间
      date.setTime(start)
      // var _start = date.Format("yyyy-MM-dd");
      var _start = date.toLocaleDateString().split('/').join('-')
      date.setTime(end)
      // var _end = date.Format("yyyy-MM-dd");
      var _end = date.toLocaleDateString().split('/').join('-')
      return _start + "---" + _end
    }
  } else {//一年54周情况    
    var cnt = 0// 获取距离周末的天数    
    if (_week == 0 && weeks == 1) {//第一周    
      cnt = 0
    } else if (_week == 0) {
      cnt = 7
    } else if (_week == 1) {
      cnt = 6
    } else if (_week == 2) {
      cnt = 5
    } else if (_week == 3) {
      cnt = 4
    } else if (_week == 4) {
      cnt = 3
    } else if (_week == 5) {
      cnt = 2
    } else if (_week == 6) {
      cnt = 1
    }
    cnt += 1//加1表示以星期一为一周的第一天    
    // 将这个长整形时间加上第N周的时间偏移    
    time += 24 * 3600000 //第2周开始时间    
    var nextYear = new Date(parseInt(year, 10) + 1, "0", "1")
    var nextWeek = nextYear.getDay()
    var lastcnt = 0 //获取最后一周开始时间到周末的天数    
    if (nextWeek == 0) {
      lastcnt = 6
    } else if (nextWeek == 1) {
      lastcnt = 0
    } else if (nextWeek == 2) {
      lastcnt = 1
    } else if (nextWeek == 3) {
      lastcnt = 2
    } else if (nextWeek == 4) {
      lastcnt = 3
    } else if (nextWeek == 5) {
      lastcnt = 4
    } else if (nextWeek == 6) {
      lastcnt = 5
    }
    if (weeks == 1) {//第1周特殊处理
      // var start = date.Format("yyyy-MM-dd");
      var start = date.toLocaleDateString().split('/').join('-')
      date.setTime(time - 24 * 3600000)
      alert(start + '--' + date)
      return _start + "---" + date
    } else if (weeks == 54) {//第54周特殊处理    
      var start = time + (weeks - 2) * 7 * 24 * 3600000 //第54周开始时间    
      var end = time + (weeks - 2) * 7 * 24 * 3600000 + lastcnt * 24 * 3600000 - 24 * 3600000 //第53周结束时间
      date.setTime(start)
      // var _start = date.Format("yyyy-MM-dd"); 
      var _start = date.toLocaleDateString().split('/').join('-')
      date.setTime(end)
      // var _end = date.Format("yyyy-MM-dd");
      var _end = date.toLocaleDateString().split('/').join('-')
      return _start + "---" + _end
    } else {
      var start = time + (weeks - 2) * 7 * 24 * 3600000 //第n周开始时间    
      var end = time + (weeks - 1) * 7 * 24 * 3600000 - 24 * 3600000 //第n周结束时间
      date.setTime(start)
      // var _start = date.Format("yyyy-MM-dd");
      var _start = date.toLocaleDateString().split('/').join('-')
      date.setTime(end)
      // var _end = date.Format("yyyy-MM-dd");
      var _end = date.toLocaleDateString().split('/').join('-')
      return _start + "---" + _end
    }
  }
}

// 计算某年某月的日期范围
export function monthGetDate (year, months) {
  var year = year
  var month = months
  month = month < 10 ? "0" + month : month
  var firstday = year + "-" + month + "-" + "01"
  var lastday = ""
  if (month == "01" || month == "03" || month == "05" || month == "07" || month == "08" || month == "10" || month == "12") {
    lastday = year + "-" + month + "-" + 31
  } else if (month == "02") {
    if ((year % 4 == 0 && year % 100 != 0) || (year % 100 == 0 && year % 400 == 0)) {
      lastday = year + "-" + month + "-" + 29
    } else {
      lastday = year + "-" + month + "-" + 28
    }
  } else {
    lastday = year + "-" + month + "-" + 30
  }
  return firstday + '---' + lastday
}

//生成随机字符串方法
export function getString () {
  let time = new Date()
  time = time.getTime()

  return `${Math.random().toString(36).substr(2, 10)}${time}`
}

//升序排序
export function bubbleSortUp (arr, flag) {
  for (var i = 0; i < arr.length; i++) {
    for (var j = 0; j < arr.length - i - 1; j++) {
      if (arr[j][flag] > arr[j + 1][flag]) {
        var c = arr[j];
        arr[j] = arr[j + 1];
        arr[j + 1] = c;
      }
    }
  }

  return arr;
}

//降序排序
export function bubbleSortDown (arr, flag) {
  for (var i = 0; i < arr.length; i++) {
    for (var j = 0; j < arr.length - i - 1; j++) {
      if (arr[j][flag] < arr[j + 1][flag]) {
        var c = arr[j + 1];
        arr[j + 1] = arr[j];
        arr[j] = c;
      }
    }
  }

  return arr;
}

//减法精度处理
export function floatSub (arg1, arg2) {
  var r1, r2, m, n;
  try { r1 = arg1.toString().split(".")[1].length } catch (e) { r1 = 0 }
  try { r2 = arg2.toString().split(".")[1].length } catch (e) { r2 = 0 }
  m = Math.pow(10, Math.max(r1, r2));
  n = (r1 >= r2) ? r1 : r2;

  return ((arg1 * m - arg2 * m) / m).toFixed(n);
}

