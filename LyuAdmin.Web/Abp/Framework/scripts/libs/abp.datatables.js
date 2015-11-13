var abp = abp || {};
(function ($) {
	var base = {
		//_create: $.hik.jtable.prototype._create
	};
	
	var datatables = function(userOptions) {
		var self = this;
		var config = {
			'default': {
				"language": {
					"processing": "正在加载数据...",
					"search": "搜索",
					"lengthMenu": "每页 _MENU_ 条记录",
					"zeroRecords": "没有找到记录",
					"info": "第 _PAGE_ 页 ( 总共 _PAGES_ 页 )",
					"infoEmpty": "无记录",
					"infoFiltered": "(从 _MAX_ 条记录过滤)"
				},
				"bSort": false,
				"processing": true,
				"serverSide": true
			}
		};
		self.config = config;
	}
	
	datatables.prototype.init = function (userOptions) {
		var self = this;
		var opts = $.extend({}, self.config['default'], userOptions);
		if (userOptions.ajax) {
			var ajaxUrl = userOptions.ajax;
			opts.ajax = function (data, callback, settings) {
				$.ajax({
					url: ajaxUrl,
					data: JSON.stringify(data),
					dataType: 'json',
					type: 'POST',
					contentType: 'application/json',
					success: function (json) {
						callback(json.result);
					}
				});
			}
		}
		return $(userOptions.table).DataTable(opts);
	}
	abp.datatables = new datatables();
})(jQuery)