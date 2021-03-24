<!DOCTYPE html>
<html>
<head>
    <title></title>
    <link href="./bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen">
    <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>

<body>
<%--<div class="container">
    <form  class="form-horizontal"  role="form">
        <fieldset>
            <legend>Test</legend>
            <div class="form-group">
                <label for="dtp_input1" class="col-md-2 control-label">DateTime Picking</label>
                <div class="input-group date form_datetime col-md-5" data-date="1979-09-16T05:25:07Z" data-date-format="dd MM yyyy - HH:ii p" data-link-field="dtp_input1">
                    <input class="form-control" size="16" type="text" value="" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
					<span class="input-group-addon"><span class="glyphicon glyphicon-th"></span></span>
                </div>
				<input type="hidden" id="dtp_input1" value="" /><br/>
            </div>
			<div class="form-group">
                <label for="dtp_input2" class="col-md-2 control-label">Date Picking</label>
                <div class="input-group date form_date col-md-5" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
                    <input class="form-control" size="16" type="text" value="" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
					<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
				<input type="hidden" id="dtp_input2" value="" /><br/>
            </div>
			<div class="form-group">
                <label for="dtp_input3" class="col-md-2 control-label">Time Picking</label>
                <div class="input-group date form_time col-md-5" data-date="" data-date-format="hh:ii" data-link-field="dtp_input3" data-link-format="hh:ii">
                    <input class="form-control" size="16" type="text" value="" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
					<span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                </div>
				<input type="hidden" id="dtp_input3" value="" /><br/>
            </div>
        </fieldset>
    </form>
</div>

<script type="text/javascript" src="./jquery/jquery-1.8.3.min.js" charset="UTF-8"></script>
<script type="text/javascript" src="./bootstrap/js/bootstrap.min.js"></script>
<script type="text/javascript" src="../js/bootstrap-datetimepicker.js" charset="UTF-8"></script>
<script type="text/javascript" src="../js/locales/bootstrap-datetimepicker.fr.js" charset="UTF-8"></script>
<script type="text/javascript">
    $('.form_datetime').datetimepicker({
        //language:  'fr',
        weekStart: 1,
        todayBtn:  1,
		autoclose: 1,
		todayHighlight: 1,
		startView: 2,
		forceParse: 0,
        showMeridian: 1
    });
	$('.form_date').datetimepicker({
        language:  'fr',
        weekStart: 1,
        todayBtn:  1,
		autoclose: 1,
		todayHighlight: 1,
		startView: 2,
		minView: 2,
		forceParse: 0
    });
	$('.form_time').datetimepicker({
        language:  'fr',
        weekStart: 1,
        todayBtn:  1,
		autoclose: 1,
		todayHighlight: 1,
		startView: 1,
		minView: 0,
		maxView: 1,
		forceParse: 0
    });
</script>--%>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet"/>
<script src="//code.jquery.com/jquery-1.11.0.min.js"></script>
<script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/js/bootstrap-datepicker.js"></script>

<style>
    .datepicker {
      z-index: 1600 !important; /* has to be larger than 1050 */
    }
</style>

<div class="well">
  <button type="button" id="add">Add</button>
</div>
<div id="myModal" class="modal">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4></h4>
      </div>
      <div class="modal-body">
      </div>
    </div>
  </div>
</div>
    <script type="text/javascript">
    $('#myModal').on('shown.bs.modal', function() {
  $('.input-group.date').datepicker({
    format: "dd/mm/yyyy",
    startDate: "01-01-2015",
    endDate: "01-01-2020",
    todayBtn: "linked",
    autoclose: true,
    todayHighlight: true,
    container: '#myModal modal-body'
  });
});

$("[id=add]").click(function() {
  $("#myModal .modal-header h4").html("Request for Change");
  $("#myModal .modal-body").html('<form class="form-horizontal" role="form"><br /><br /><label class="col-sm-2 control-label">Date Required</label><div class="col-sm-3"><div class="input-group date col-sm-8"><input type="text" class="form-control" id="DateRequired"><span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span></div></div></form>');
  $("#myModal").modal("show");
});
        </script>
</body>
</html>



<form class="form-horizontal" role="form">
    <br />
    <br />
    <label class="col-sm-2 control-label">Date Required</label>
    <div class="col-sm-3">
        <div class="input-group date col-sm-8">
            <input type="text" class="form-control" id="DateRequired"><span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span></div>
    </div>
</form>
